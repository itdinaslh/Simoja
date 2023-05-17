using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simoja.Entity;
using Simoja.Repository;
using Simoja.Helpers;

namespace Simoja.Controllers;

public class JenisIzinLingkunganController : Controller
{
    private readonly IJenisIzinLingkungan repo;

    public JenisIzinLingkunganController(IJenisIzinLingkungan repo) => this.repo = repo;

    [HttpGet("/master/kawasan/jenis-izin-lingkungan")]
    public IActionResult Index()
    {
        return View("~/Views/Master/JenisIzinLingkungan/Index.cshtml");
    }

    [HttpGet("/master/kawasan/jenis-izin-lingkungan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Master/JenisIzinLingkungan/AddEdit.cshtml", new JenisIzinLingkungan());
    }

    [HttpGet("/master/kawasan/jenis-izin-lingkungan/edit")]
    public async Task<IActionResult> Edit(int jenisID)
    {
        JenisIzinLingkungan? data = await repo.JenisIzinLingkungans.FirstOrDefaultAsync(x => x.JenisIzinLingkunganID == jenisID);

        if (data is not null)
        {
            return PartialView("~/Views/Master/JenisIzinLingkungan/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [HttpPost("/master/kawasan/jenis-izin-lingkungan/store")]
    public async Task<IActionResult> Store(JenisIzinLingkungan jenis)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(jenis);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/JenisIzinLingkungan/AddEdit.cshtml", jenis);
    }
}
