using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Helpers;
using Simoja.Entity;
using System.Net;

namespace Simoja.Controllers;

[Authorize(Roles = "SimojaAngkut")]
public class JasaAngkutController : Controller {
    private IKendaraan vehicle;
    private IClient clientRepo;
    
    public JasaAngkutController(IKendaraan kRepo, IClient cRepo) {
        vehicle = kRepo; clientRepo = cRepo;
    }

    [HttpGet("/dashboard/pengangkutan")]
    public IActionResult Dashboard() {
        return View();
    }

    [HttpGet("/clients/jasa/pengangkutan/kendaraan")]
    public async Task<IActionResult> Kendaraan() {
        string? currentUser = User.Identity?.Name;

        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientId
            })
            .FirstOrDefaultAsync();

        #nullable disable
        var detail = await clientRepo.DetailAngkuts
            .Where(d => d.ClientId == thisClient.ClientId)
            .Select(d => new {
                d.JmlAngkutan
            }).FirstOrDefaultAsync();

        int jumlah = await vehicle.Kendaraans
            .Where(k => k.ClientId == thisClient.ClientId)
            .CountAsync();

        bool isForbid = true;

        if (jumlah < detail.JmlAngkutan)
            isForbid = false;

        return View(new KendaraanIndexVM {
            KendaranBerizin = detail.JmlAngkutan,
            KendaraanDiinput = jumlah,
            Forbid = isForbid
        });
    }

    [HttpGet("/clients/jasa/pengangkutan/kendaraan/create")]
    public IActionResult KendaraanCreate() {
        return View();
    }
}