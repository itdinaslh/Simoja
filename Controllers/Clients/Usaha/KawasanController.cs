using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Helpers;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;

namespace Simoja.Controllers;

[Authorize(Roles = "PkmUsaha")]
public class KawasanController : Controller
{
    private readonly IIzinKegiatan repo;
    private readonly IClient clientRepo;

    public KawasanController(IIzinKegiatan repo, IClient clientRepo)
    {
        this.repo = repo;
        this.clientRepo = clientRepo;
    }

    [HttpGet("/clients/usaha-kegiatan/izin")]
    public IActionResult Perizinan()
    {
        //Guid? curClient = await clientRepo.Clients.Where(c => c.UserId == User.Identity!.Name!.ToString())
        //    .Select(cli => cli.ClientID)
        //    .FirstOrDefaultAsync();

        //if (curClient != null)
        //{
        //    IzinAngkut? detail = await izinRepo.IzinAngkuts.Where(ang => ang.ClientID == curClient).FirstOrDefaultAsync();
        //    return View("~/Views/Client/JasaAngkut/Perizinan.cshtml", new RegAngkutModel
        //    {
        //        IzinAngkut = new IzinAngkut
        //        {
        //            DokumenIzin = "/upload"
        //        }
        //    });
        //}

        //return NotFound();

        return View("~/Views/Client/Usaha/Perizinan.cshtml");
    }

    [HttpPost("/clients/usaha-kegiatan/kawasan/store")]
    public async Task<IActionResult> StoreKawasan(KawasanCreateVM model)
    {
        Client? client = await clientRepo.Clients.Where(c => c.UserId == User.Identity!.Name).FirstOrDefaultAsync();

        if (client != null)
        {
            model.Kawasan.IzinKegiatanID = client.ClientID;
            model.Kawasan.TglTerbitIzin = model.TglIzin != null ? DateOnly.ParseExact(model.TglIzin, "dd-MM-yyyy") : null;
            if (model.FileIzin != null)
            {
                model.Kawasan.DokumenIzin = await Upload.Kawasan(model.FileIzin, client.ClientID.ToString());
            }
        }

        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(model.Kawasan);

            return Json(Result.Success());
        }

        return Json(Result.Failed());
    }
}
