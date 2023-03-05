using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;

namespace Simoja.Controllers;

[Authorize]
public class AdminAngkutController : Controller
{
    private readonly IClient repo;

    public AdminAngkutController(IClient repo)
    {
        this.repo = repo;
    }

    [HttpGet("/admin/data/jasa/angkutan/details")]
    [Authorize(Roles = "SysAdmin, PkmAdmin")]
    public async Task<IActionResult> Details(Guid theID)
    {
        Client? data = await repo.Clients
            .Include(x => x.Kelurahan.Kecamatan.Kabupaten)
            .Include(u => u.JenisUsaha)
            .FirstOrDefaultAsync(x => x.ClientID == theID);

        if (data is not null)
        {
            return View("~/Views/Admin/Angkutan/Details.cshtml", new DetailAngkutanVM
            {
                Client = data,
                NamaKabupaten = data.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten,
                NamaKecamatan = data.Kelurahan.Kecamatan.NamaKecamatan,
                NamaKelurahan = data.Kelurahan.NamaKelurahan,
                NamaJenisUsaha = data.JenisUsaha.NamaJenis
            });
        }

        return NotFound();
    }
}
