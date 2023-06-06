using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simoja.Entity;
using Simoja.Helpers;
using Simoja.Models;
using Simoja.Repository;

namespace Simoja.Controllers;

public class IzinAngkutController : Controller
{
    private readonly IIzinAngkut izinRepo;
    private readonly IKendaraan kRepo;
    private readonly IClient clientRepo;

    public IzinAngkutController(IIzinAngkut izinRepo, IClient client, IKendaraan kRepo)
    {
        this.izinRepo = izinRepo;
        this.kRepo = kRepo;
        clientRepo = client;
    }

    [HttpGet("/clients/pengangkutan/izin")]
    public async Task<IActionResult> Perizinan()
    {
        Guid? curClient = await clientRepo.Clients.Where(c => c.UserId == User.Identity!.Name!.ToString())
            .Select(cli => cli.ClientID)
            .FirstOrDefaultAsync();

        if (curClient != null)
        {
            IzinAngkut? detail = await izinRepo.IzinAngkuts.Where(ang => ang.ClientID == curClient).FirstOrDefaultAsync();
            return View("~/Views/Client/JasaAngkut/Perizinan.cshtml", new RegAngkutModel
            {
                IzinAngkut = new IzinAngkut
                {
                    DokumenIzin = "/upload"
                }
            });
        }

        return NotFound();
    }

    [HttpPost("/clients/pengangkutan/izin/store")]
    // [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveIzinAngkut(RegAngkutModel model)
    {
        Client? client = await clientRepo.Clients.Where(c => c.UserId == User.Identity!.Name).FirstOrDefaultAsync();

        model.IzinAngkut.ClientID = client!.ClientID;
        model.IzinAngkut.TglTerbitIzin = DateOnly.ParseExact(model.TglAwal, "dd/MM/yyyy");
        model.IzinAngkut.TglAkhirIzin = DateOnly.ParseExact(model.TglAkhir, "dd/MM/yyyy");
        model.IzinAngkut.DokumenIzin = await Upload.IzinAngkut(model.FileIzin, client.ClientID.ToString());
        model.IzinAngkut.UniqueID = Guid.NewGuid();

        if (ModelState.IsValid)
        {
            await clientRepo.SaveIzinAngkut(model.IzinAngkut);

            return Json(Result.Success());
        }

        return View("~/Views/Client/RegisterAngkut.cshtml", model);
    }

    [HttpGet("/clients/pengangkutan/izin/kendaraan/create")]
    public IActionResult Choise(Guid izin)
    {
        return PartialView("~/Views/Client/JasaAngkut/KendaraanChoice.cshtml", new KendaraanChoiceVM
        {

            IzinID = izin
        });
    }

    [HttpPost("/clients/pengangkutan/izin/kendaraan/store")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddKendaraanToIzin(KendaraanChoiceVM model)
    {
        if (ModelState.IsValid)
        {
            Kendaraan? vehicle = await kRepo.Kendaraans.FirstOrDefaultAsync(x => x.KendaraanID == model.KendaraanID);

            if (vehicle != null)
            {
                await izinRepo.AddKendaraan(model.IzinID, vehicle);

                return Json(Result.Success());
            }            
        }

        return PartialView("~/Views/Client/JasaAngkut/KendaraanChoice.cshtml", new KendaraanChoiceVM
        {

            IzinID = model.IzinID,
            KendaraanID = model.KendaraanID
        });
    }
}    
