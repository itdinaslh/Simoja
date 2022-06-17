using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace Simoja.Controllers.api;

[ApiController]
[Route("[controller]")]
public class StatusKelolaApiController : Controller {
    private IStatusKelola repo;

    public StatusKelolaApiController(IStatusKelola jenisRepo) => repo = jenisRepo;

    [HttpPost("/api/master/kawasan/status")]
    public async Task<IActionResult> StatusKelolaTable() {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;

        var init = repo.StatusKelolas;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection))) {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue)) {
            init = init.Where(a => a.NamaStatus.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
    }

    [HttpGet("/api/master/kawasan/status/search")]
    public async Task<IActionResult> SearchStatusKelola(string? term) {
        var data = await repo.StatusKelolas
            .Where(j => !String.IsNullOrEmpty(term) ?
                j.NamaStatus.ToLower().Contains(term.ToLower()) : true            
            ).Select(jen => new {
                id = jen.StatusKelolaID,
                namaStatus = jen.NamaStatus
            }).Take(5).ToListAsync();

        return Ok(data);
    }
}