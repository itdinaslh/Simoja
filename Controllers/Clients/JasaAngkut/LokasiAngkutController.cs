using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Models;

namespace Simoja.Controllers;


[Authorize(Roles = "PkmAngkut")]
public class LokasiAngkutController : Controller
{
    [HttpGet("/clients/pengangkutan/lokasi-angkut")]
    public IActionResult Index() => View("~/Views/Client/JasaAngkut/LokasiAngkut.cshtml");

    [HttpGet("/clients/pengangkutan/lokasi-angkut/create")]
    public IActionResult Create()
    {
        return View("~/Views/Client/JasaAngkut/LokasiAngkutCreate.cshtml" ,new LokasiAngkutCreateVM
        {
            LokasiAngkut = new LokasiAngkut()
        });
    }
}
