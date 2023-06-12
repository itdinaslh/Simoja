using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Helpers;
using SharedLibrary.Repositories.Common;
using SharedLibrary.Entities.Common;

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

        var thisClient = await repo.Clients.Where(c => c.ClientPkm!.UserEmail == currentUser)
            .Select(c => new {
                c.ClientID,
                //c.JenisUsahaID,
                c.IsVerified
            })
            .FirstOrDefaultAsync();

        if (thisClient is null) {
            return RedirectToAction("Register", "Client");
        } else if (User.IsInRole("PkmAngkut")) {
			return RedirectToAction("IndexAngkut");
		} else if (User.IsInRole("PkmOlah")) {
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

    [HttpGet("/dashboard/pengangkutan")]
    public IActionResult IndexAngkut()
    {
        return View("~/Views/Client/JasaAngkut/Dashboard.cshtml");
    }

    [HttpGet("/dashboard/pengolahan")]
    public IActionResult IndexOlah() {
        return View();
    }

    [HttpGet("/dashboard/usaha-kegiatan")]
    public IActionResult IndexUsaha() {
        return View("~/Views/Client/Usaha/Dashboard.cshtml");
    }

    [HttpGet("/clients/profile")]
    public async Task<IActionResult> Profile()
    {
        Client? client = await repo.Clients
            //.Include(j => j.JenisUsaha)
            .Include(kel => kel.ClientPkm!.Kelurahan.Kecamatan.Kabupaten)
            .FirstOrDefaultAsync(x => x.ClientPkm!.UserEmail == User.Identity!.Name);

        if (client is not null)
        {
            return View(new ProfileVM
            {
                Client = client,
                NamaKelurahan = client.ClientPkm!.Kelurahan.NamaKelurahan,
                KecamatanID = client.ClientPkm!.Kelurahan.KecamatanID,
                NamaKecamatan = client.ClientPkm!.Kelurahan.Kecamatan.NamaKecamatan,
                KabupatenID = client.ClientPkm!.Kelurahan.Kecamatan.KabupatenID,
                NamaKabupaten = client.ClientPkm!.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten
            });
        }

        return NotFound();
    }

}
