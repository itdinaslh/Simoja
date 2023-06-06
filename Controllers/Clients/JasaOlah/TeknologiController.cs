using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Models;

namespace Simoja.Controllers.Clients.JasaOlah
{
    public class TeknologiController : Controller
    {
        [HttpGet("/clients/pengolahan/teknologi")]
        public IActionResult Index() => View("~/Views/Client/JasaOlah/Teknologi.cshtml");

        [HttpGet("/clients/pengolahan/teknologi/create")]
        public IActionResult Create(Guid izin)
        {
            return PartialView("~/Views/Client/JasaOlah/TeknologiCreate.cshtml", new KendaraanCreateVM
            {
                Kendaraan = new Kendaraan(),
                IzinID = izin
            });
        }
    }

    
}
