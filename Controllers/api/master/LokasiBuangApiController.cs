using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;

namespace Simoja.Controllers.api;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LokasiBuangApiController : ControllerBase
{
    private readonly ILokasiBuang repo;

    public LokasiBuangApiController(ILokasiBuang repo) { this.repo = repo; }

    [HttpGet("/api/master/lokasi-buang/search")]
    public async Task<IActionResult> Search(string? term)
    {
        var data = await repo.LokasiBuangs
            .Where(j => !String.IsNullOrEmpty(term) ?
                j.NamaLokasi.ToLower().Contains(term.ToLower()) : true
            ).Select(jen => new {
                id = jen.LokasiBuangID,
                data = jen.NamaLokasi
            }).ToListAsync();

        return Ok(data);
    }
}
