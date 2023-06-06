using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simoja.Entity;
using Simoja.Helpers;
using Simoja.Models;
using Simoja.Repository;

namespace Simoja.Controllers
{
    public class IzinOlahController : Controller
    {
        private readonly IIzinAngkut izinRepo;
        private readonly IClient clientRepo;

        public IzinOlahController(IIzinAngkut izinRepo, IClient client)
        {
            this.izinRepo = izinRepo;
            clientRepo = client;
        }

        [HttpGet("/clients/pengolahan/izin")]
        public async Task<IActionResult> Perizinan()
        {
            Guid? curClient = await clientRepo.Clients.Where(c => c.UserId == User.Identity!.Name!.ToString())
                .Select(cli => cli.ClientID)
                .FirstOrDefaultAsync();

            if (curClient != null)
            {
                IzinAngkut? detail = await izinRepo.IzinAngkuts.Where(ang => ang.ClientID == curClient).FirstOrDefaultAsync();
                return View("~/Views/Client/JasaOlah/Perizinan.cshtml", new RegAngkutModel
                {
                    IzinAngkut = new IzinAngkut
                    {
                        DokumenIzin = "/upload"
                    }
                });
            }

            return NotFound();
        }

        [HttpPost("/clients/pengolahan/izin/store")]
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

            return View("~/Views/Client/RegisterOlah.cshtml", model);
        }

        [HttpGet("/clients/pengolahan/izin/teknologi/create")]
        public IActionResult Choise(Guid izin)
        {
            return PartialView("~/Views/Client/JasaOlah/TeknologiChoice.cshtml", new KendaraanChoiceVM
            {

                IzinID = izin
            });
        }
    }
}
