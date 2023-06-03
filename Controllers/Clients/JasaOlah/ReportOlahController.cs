using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Models;

namespace Simoja.Controllers.Clients.JasaOlah
{
    public class ReportOlahController : Controller
    {
        [HttpGet("/clients/pengolahan/report")]
        public IActionResult Index()
        {
            return View("~/Views/Client/JasaOlah/Report/Index.cshtml");
        }

        [HttpGet("/clients/pengolahan/report/create")]
        public IActionResult Create()
        {
            return PartialView("~/Views/Client/JasaOlah/Report/Create.cshtml");
        }
    }
}
