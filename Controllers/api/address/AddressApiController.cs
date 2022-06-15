using Microsoft.AspNetCore.Mvc;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace Simoja.Controllers.api;

[ApiController]
[Route("[controller]")]
public class AddressApiController : Controller {
    private IAddressRepo repo;

    public AddressApiController(IAddressRepo thisRepo) => repo = thisRepo;

    [HttpGet("/api/address/kabupaten/search")]
    public async Task<IActionResult> SearchKabupaten(string? term) {
        var data = await repo.Kabupatens
            .Where(c => c.ProvinsiID == "31")
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaKabupaten.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.KabupatenID,
                namaKabupaten = s.NamaKabupaten
            }).Take(10).ToListAsync();

        return Ok(data);   
    }

    [HttpGet("/api/address/kecamatan/search")]
    public async Task<IActionResult> SearchKecamatan(string theID,string? term) {
        var data = await repo.Kecamatans
            .Where(kab => kab.KabupatenID == theID)
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaKecamatan.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.KecamatanID,
                namaKecamatan = s.NamaKecamatan
            }).Take(10).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/address/kelurahan/search")]
    public async Task<IActionResult> SearchKelurahan(string theID, string? term) {
        var data = await repo.Kelurahans
            .Where(kec => kec.KecamatanID == theID)
            .Where(k => !String.IsNullOrEmpty(term) ? 
                k.NamaKelurahan.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.KelurahanID,
                namaKelurahan = s.NamaKelurahan
            }).Take(10).ToListAsync();

        return Ok(data);
    }

}