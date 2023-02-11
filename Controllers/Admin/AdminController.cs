using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Helpers;
using Simoja.Entity;
using System.Net;

namespace Simoja.Controllers;

[Authorize(Roles = "SimojaAdmin, SysAdmin")]
public class AdminController : Controller {
    private IClient repo;

    public AdminController(IClient cRepo) {
        repo = cRepo;
    }

    [HttpGet("/admin/data/jasa/verifikasi")]
    public IActionResult JasaUnverified() {
        return View("~/Views/Admin/JasaUnverified.cshtml");
    }

    [HttpGet("/admin/jasa/details")]
    public async Task<IActionResult> Details(int type, Guid theID)
    {
        Client? client = await repo.Clients.Where(c => c.ClientID == theID)
            .Include(k => k.Kelurahan.Kecamatan.Kabupaten)
            .FirstOrDefaultAsync();

        if (client is not null)
        {
            return View("~/Views/Admin/Details.cshtml", new ClientDetailVM
            {
                Client = client,
                KabupatenId = client.Kelurahan.Kecamatan.Kabupaten.KabupatenID,
                NamaKabupaten = client.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten,
                KecamatanId = client.Kelurahan.Kecamatan.KecamatanID,
                NamaKecamatan = client.Kelurahan.Kecamatan.NamaKecamatan,
                NamaKelurahan = client.Kelurahan.NamaKelurahan
            });
        }

        return NotFound();
    }

    [HttpPost("/admin/jasa/details/update")]
    public async Task<IActionResult> UpdateDetailsJasa(ClientDetailVM model)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveClientAsync(model.Client!);

            return Json(Result.Success());
        }        

        return Json(Result.Failed());
    }

    [HttpPost("/admin/clients/verifikasi")]
    public async Task<IActionResult> VerifyCLient(Guid theID)
    {
        Client? client = await repo.Clients.Where(c => c.ClientID == theID).FirstOrDefaultAsync();

        if (client is not null)
        {
            client.IsVerified = true;

            await repo.VerifyClient(theID, true);

            return Json(Result.Success());
        }

        return Json(Result.Failed());
    }
}