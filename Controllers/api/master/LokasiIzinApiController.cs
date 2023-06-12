using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Repositories.Common;

namespace Simoja.Controllers.api;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LokasiIzinApiController : ControllerBase
{
    private readonly ILokasiIzin repo;

    public LokasiIzinApiController(ILokasiIzin repo) { this.repo = repo; }

    [HttpGet("/api/master/lokasi-izin/search")]
    public async Task<IActionResult> Search(string? term)
    {
        var data = await repo.LokasiIzins
            .Where(j => !String.IsNullOrEmpty(term) ?
                j.NamaLokasi.ToLower().Contains(term.ToLower()) : true
            ).Select(jen => new {
                id = jen.LokasiIzinID,
                data = jen.NamaLokasi
            }).ToListAsync();

        return Ok(data);
    }
}
