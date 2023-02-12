using Microsoft.AspNetCore.Mvc;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Simoja.Controllers.api;

[ApiController]
[Route("[controller]")]
public class AddressApiController : Controller {
    private IAddressRepo repo;

    public AddressApiController(IAddressRepo thisRepo) => repo = thisRepo;

    [HttpGet("/api/address/provinsi/search")]
    public async Task<IActionResult> ProvinsiSearch(string? term)
    {
        var data = await repo.Provinsis
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaProvinsi.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.ProvinsiID,
                data = s.NamaProvinsi
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/address/kabupaten/search")]
    public async Task<IActionResult> KabupatenSearch(string? term, string provID)
    {
        var data = await repo.Kabupatens
            .Where(k => k.ProvinsiID == provID)
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaKabupaten.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.KabupatenID,
                data = s.NamaKabupaten
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/address/kecamatan/search")]
    public async Task<IActionResult> KecamatanSearch(string? term, string kab)
    {
        var data = await repo.Kecamatans
            .Where(k => k.KabupatenID == kab)
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaKecamatan.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.KecamatanID,
                data = s.NamaKecamatan
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/address/kelurahan/search")]
    public async Task<IActionResult> KelurahanSearch(string? term, string kec)
    {
        var data = await repo.Kelurahans
            .Where(k => k.KecamatanID == kec)
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaKelurahan.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.KelurahanID,
                data = s.NamaKelurahan
            }).ToListAsync();

        return Ok(data);
    }

}