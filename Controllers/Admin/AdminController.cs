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
    public async Task<IActionResult> Details(Guid theID)
    {
        Client? client = await repo.Clients.Where(c => c.ClientGuid == theID)
            .Include(d => d.DetailAngkut)
            .Include(kel => kel.Kelurahan.Kecamatan.Kabupaten)
            .FirstOrDefaultAsync();        

        if (client is not null)
        {
            DateOnly TglAwal, TglAkhir;

            if (client!.JenisUsahaId == 1)
            {
                TglAwal = client.DetailAngkut.TglTerbitIzin;
                TglAkhir = client.DetailAngkut.TglAkhirIzin;
            } else if (client!.JenisUsahaId == 2)
            {
                TglAwal = client.DetailOlah.TglTerbitIzin;
                TglAkhir = client.DetailOlah.TglAkhirIzin;
            }

            return View("~/Views/Admin/Details.cshtml", new ClientAngkutDetailVM
            {
                Client = client,
                TglTerbitIzin = TglAwal.ToString("dd/MM/yyyy"),
                TglAkhirIzin = TglAkhir.ToString("dd/MM/yyyy"),
                KabupatenId = client.Kelurahan.Kecamatan.Kabupaten.KabupatenID,
                NamaKabupaten = client.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten,
                KecamatanId = client.Kelurahan.Kecamatan.KecamatanID,
                NamaKecamatan = client.Kelurahan.Kecamatan.NamaKecamatan,
                NamaKelurahan = client.Kelurahan.NamaKelurahan
            });
        }

        return NotFound();
    }
}