using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace Simoja.Controllers.api;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "SysAdmin, SimojaAdmin")]
public class JenisKendaraanApiController : Controller {
    private IKendaraan repo;

    public JenisKendaraanApiController(IKendaraan kRepo) => repo = kRepo;

    [HttpPost("/api/master/kendaraan/jenis")]
    public async Task<IActionResult> JenisKendaraanTable() {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;

        var init = repo.JenisKendaraans;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection))) {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue)) {
            init = init.Where(a => a.NamaJenis.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
    }

    [HttpGet("/api/master/kendaraan/jenis/search")]
    [AllowAnonymous]
    public async Task<IActionResult> SearchJenisKendaraan(string? term) {
        var data = await repo.JenisKendaraans
            .Where(j => !String.IsNullOrEmpty(term) ?
                j.NamaJenis.ToLower().Contains(term.ToLower()) : true            
            ).Select(jen => new {
                id = jen.JenisKendaraanId,
                namaJenis = jen.NamaJenis
            }).Take(10).ToListAsync();

        return Ok(data);
    }
}