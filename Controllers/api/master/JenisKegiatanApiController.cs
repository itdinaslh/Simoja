using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using SharedLibrary.Repositories.Kawasan;

namespace Simoja.Controllers.api;

[ApiController]
[Route("[controller]")]
//[Authorize(Roles = "SysAdmin, SimojaAdmin")]
public class JenisKegiatanApiController : Controller {
    private readonly IJenisKegiatan repo;

    public JenisKegiatanApiController(IJenisKegiatan jenisRepo) => repo = jenisRepo;

    [HttpPost("/api/master/kawasan/jenis")]
    public async Task<IActionResult> JenisKegiatanTable() {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;

        var init = repo.JenisKegiatans;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection))) {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue)) {
            init = init.Where(a => a.NamaKegiatan.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
    }

    [HttpGet("/api/master/kawasan/jenis/search")]
    public async Task<IActionResult> SearchKegiatan(string? term) {
        var data = await repo.JenisKegiatans
            .Where(j => !String.IsNullOrEmpty(term) ?
                j.NamaKegiatan.ToLower().Contains(term.ToLower()) : true            
            ).Select(jen => new {
                id = jen.JenisKegiatanID,
                data = jen.NamaKegiatan
            }).ToListAsync();

        return Ok(data);
    }
}