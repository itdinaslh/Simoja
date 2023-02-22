using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Entity;
using Simoja.Helpers;

namespace Simoja.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly IClient repo;    

    public HomeController(IClient cRepo)
    {
        repo = cRepo;
    }

    [HttpGet("/dashboard")]
    public async Task<IActionResult> Index()
    {
        if (User.IsInRole("SysAdmin") || User.IsInRole("PkmAdmin")) {
            return View();
        }

        string? currentUser = User.Identity?.Name;

        var thisClient = await repo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientID,
                c.JenisUsahaID,
                c.IsVerified
            })
            .FirstOrDefaultAsync();

        if (thisClient is null) {
            return RedirectToAction("Register", "Client");
        } else if (thisClient.JenisUsahaID == 1) {
			return RedirectToAction("Dashboard", "JasaAngkut");
		} else if (thisClient.JenisUsahaID == 2) {
			return RedirectToAction("IndexOlah");
		} else {
			return RedirectToAction("IndexUsaha");
		}        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet("/dashboard/pengolahan")]
    public IActionResult IndexOlah() {
        return View();
    }

    [HttpGet("/dashboard/usaha-kegiatan")]
    public IActionResult IndexUsaha() {
        return View();
    }

    [HttpGet("/clients/profile")]
    public async Task<IActionResult> Profile()
    {
        Client? client = await repo.Clients
            .Include(j => j.JenisUsaha)
            .Include(kel => kel.Kelurahan.Kecamatan.Kabupaten)
            .FirstOrDefaultAsync(x => x.UserId == User.Identity!.Name);

        if (client is not null)
        {
            return View(new ProfileVM
            {
                Client = client,                
                NamaKelurahan = client.Kelurahan.NamaKelurahan,
                KecamatanID = client.Kelurahan.KecamatanID,
                NamaKecamatan = client.Kelurahan.Kecamatan.NamaKecamatan,
                KabupatenID = client.Kelurahan.Kecamatan.KabupatenID,
                NamaKabupaten = client.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten
            });
        }            

        return NotFound();
    }

}
