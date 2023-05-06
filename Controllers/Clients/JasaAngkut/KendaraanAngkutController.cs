using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simoja.Entity;
using Simoja.Models;
using Simoja.Repository;

namespace Simoja.Controllers;

[Authorize(Roles = "PkmAngkut")]
public class KendaraanAngkutController : Controller
{
    private readonly IKendaraan vehicle;
    private readonly IClient clientRepo;

    public KendaraanAngkutController(IKendaraan vehicle, IClient clientRepo)
    {
        this.vehicle = vehicle;
        this.clientRepo = clientRepo;
    }

    [HttpGet("/clients/jasa/pengangkutan/kendaraan")]
    public async Task<IActionResult> Kendaraan()
    {
        string? currentUser = User.Identity!.Name;

        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientID
            })
            .FirstOrDefaultAsync();

        var detail = await clientRepo.IzinAngkuts
            .Where(d => d.ClientID == thisClient!.ClientID)
            .SumAsync(i => i.JmlAngkutan);

        int jumlah = await vehicle.Kendaraans
            .Where(k => k.ClientID == thisClient!.ClientID)
            .CountAsync();

        bool isForbid = false;

        return View("~/Views/Client/JasaAngkut/Kendaraan.cshtml", new KendaraanIndexVM
        {
            KendaranBerizin = detail,
            KendaraanDiinput = jumlah,
            Forbid = isForbid
        });
    }

    [HttpGet("/clients/jasa/pengangkutan/kendaraan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Client/JasaAngkut/KendaraanCreate.cshtml", new KendaraanCreateVM
        {
            Kendaraan = new Kendaraan()
        });
    }
}
