using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Entities.Common;
using SharedLibrary.Entities.Transportation;
using SharedLibrary.Repositories.Common;
using SharedLibrary.Repositories.Transportation;
using Simoja.Helpers;
using Simoja.Models;

namespace Simoja.Controllers;

public class IzinAngkutController : Controller
{
    private readonly IKendaraan kRepo;
    private readonly IClient clientRepo;
    private readonly IIzinAngkut izinRepo;

    public IzinAngkutController(IClient client, IKendaraan kRepo, IIzinAngkut izinRepo)
    {        
        this.kRepo = kRepo;
        clientRepo = client;
        this.izinRepo = izinRepo;

    }

    [HttpGet("/clients/pengangkutan/izin")]
    public async Task<IActionResult> Perizinan()
    {
        Guid? curClient = await clientRepo.Clients.Where(c => c.ClientPkm!.UserEmail == User.Identity!.Name!.ToString())
            .Select(cli => cli.ClientID)
            .FirstOrDefaultAsync();

        if (curClient != null)
        {
            IzinAngkut? detail = await clientRepo.IzinAngkuts.Where(ang => ang.ClientID == curClient).FirstOrDefaultAsync();
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveIzinAngkut(RegAngkutModel model)
    {
        Client? client = await clientRepo.Clients.Where(c => c.ClientPkm!.UserEmail == User.Identity!.Name).FirstOrDefaultAsync();

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
