using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Models;

namespace Simoja.Controllers.Clients.JasaAngkut;

public class ReportAngkutController : Controller
{
    [HttpGet("/clients/pengangkutan/report")]
    public IActionResult Index()
    {
        return View("~/Views/Client/JasaAngkut/Report/Index.cshtml");
    }

    [HttpGet("/clients/pengangkutan/report/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Client/JasaAngkut/Report/Create.cshtml");
    }
}
