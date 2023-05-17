using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;

namespace Simoja.Controllers.api;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class JenisIzinLingkunganApiController : ControllerBase
{
    private readonly IJenisIzinLingkungan repo;

    public JenisIzinLingkunganApiController(IJenisIzinLingkungan repo)
    {
        this.repo = repo;
    }

    [HttpPost("/api/master/kawasan/jenis-izin")]
    public async Task<IActionResult> JenisIzinLingkunganTable()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;

        var init = repo.JenisIzinLingkungans;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.NamaJenisIzin.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/master/kawasan/jenis-izin/search")]
    public async Task<IActionResult> SearchJenisIzin(string? term)
    {
        var data = await repo.JenisIzinLingkungans
            .Where(j => !String.IsNullOrEmpty(term) ?
                j.NamaJenisIzin.ToLower().Contains(term.ToLower()) : true
            ).Select(jen => new {
                id = jen.JenisIzinLingkunganID,
                data = jen.NamaJenisIzin
            }).ToListAsync();

        return Ok(data);
    }
}
