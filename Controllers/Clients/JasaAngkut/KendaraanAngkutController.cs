using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simoja.Entity;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Helpers;

namespace Simoja.Controllers;

[Authorize(Roles = "PkmAngkut")]
public class KendaraanAngkutController : Controller
{
    private readonly IKendaraan vehicle;
    private readonly IClient clientRepo;

    public KendaraanAngkutController(IKendaraan vehicle, IClient clientRepo)
    {
        this.vehicle = vehicle;
        this.clientRepo = clientRepo;
    }

    [HttpGet("/clients/pengangkutan/kendaraan")]
    public async Task<IActionResult> Kendaraan()
    {
        string? currentUser = User.Identity!.Name;

        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientID
            })
            .FirstOrDefaultAsync();

        var detail = await clientRepo.IzinAngkuts
            .Where(d => d.ClientID == thisClient!.ClientID)
            .SumAsync(i => i.JmlAngkutan);

        int jumlah = await vehicle.Kendaraans
            .Where(k => k.ClientID == thisClient!.ClientID)
            .CountAsync();

        bool isForbid = false;

        return View("~/Views/Client/JasaAngkut/Kendaraan.cshtml", new KendaraanIndexVM
        {
            KendaranBerizin = detail,
            KendaraanDiinput = jumlah,
            Forbid = isForbid
        });
    }

    [HttpGet("/clients/pengangkutan/kendaraan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Client/JasaAngkut/KendaraanCreate.cshtml", new KendaraanCreateVM
        {
            Kendaraan = new Kendaraan()
        });
    }

    [HttpPost("/clients/pengangkutan/kendaraan/store")]    
    public async Task<IActionResult> StoreKendaraan(KendaraanCreateVM model)
    {
        var client = await clientRepo.Clients
            .Where(c => c.UserId == User.Identity!.Name)
            .Select(c => new {
                c.ClientID
            })
            .FirstOrDefaultAsync();

        var kendaraan = await vehicle.Kendaraans
            .Where(v => v.KendaraanID == model.Kendaraan.KendaraanID)
            .FirstOrDefaultAsync();

        Guid uid = Guid.NewGuid();

        if (kendaraan is not null)
        {
            uid = kendaraan.UniqueID;
        }
        else
        {
            uid = model.UID;
        }

        model.Kendaraan.ClientID = client!.ClientID;
        model.Kendaraan.TglSTNK = DateOnly.ParseExact(model.TglBerlakuSTNK, "dd/MM/yyyy");
        model.Kendaraan.TglKIR = DateOnly.ParseExact(model.TglBerlakuKIR, "dd/MM/yyyy");
        model.Kendaraan.UniqueID = uid;
        model.Kendaraan.DokumenSTNK = await Upload.STNK(model.FileSTNK, client!.ClientID.ToString());
        model.Kendaraan.DokumenKIR = await Upload.KIR(model.FileKIR, client!.ClientID.ToString());
        model.Kendaraan.BuktiUjiEmisi = await Upload.UjiEmisi(model.FileUjiEmisi, client!.ClientID.ToString());
        model.Kendaraan.FotoKendaraan = await Upload.FotoKendaraan(model.FotoKendaraan, client!.ClientID.ToString());

        if (ModelState.IsValid)
        {
            await vehicle.SaveKendaraanAsync(model.Kendaraan);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Client/JasaAngkut/KendaraanCreate.cshtml", model);
    }
}
