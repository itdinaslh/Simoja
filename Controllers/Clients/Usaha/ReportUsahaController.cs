using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Models;

namespace Simoja.Controllers.Clients.JasaAngkut
{
    public class ReportOlahController : Controller
    {
        [HttpGet("/clients/usaha-kegiatan/report")]
        public IActionResult Index()
        {
            return View("~/Views/Client/Usaha/Report/Index.cshtml");
        }

        [HttpGet("/clients/usaha-kegiatan/report/create")]
        public IActionResult Create()
        {
            return PartialView("~/Views/Client/Usaha/Report/Create.cshtml");
        }
    }
}
