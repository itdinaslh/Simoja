using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Simoja.Controllers;

[Authorize(Roles = "PkmUsaha")]
public class IzinUsahaController : Controller
{
    [HttpGet("/clients/usaha-kegiatan/izin")]
    public async Task<IActionResult> Perizinan()
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
}
