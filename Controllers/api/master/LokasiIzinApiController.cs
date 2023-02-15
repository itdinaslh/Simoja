using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simoja.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Simoja.Controllers.api.master
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LokasiIzinApiController : ControllerBase
    {
        private readonly ILokasiIzin repo;

        public LokasiIzinApiController(ILokasiIzin repo) { this.repo = repo; }

        [HttpGet("/api/master/lokasi-izin/search")]
        public async Task<IActionResult> Searc(string? term)
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
}
