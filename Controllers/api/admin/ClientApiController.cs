using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace Simoja.Controllers.api;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "SimojaAdmin, SysAdmin")]
public class ClientApiController : Controller {
    private IClient clientRepo;

    public ClientApiController(IClient cRepo) {
        clientRepo = cRepo;
    }

    [HttpPost("/api/admin/jasa/unverified")]
    public async Task<IActionResult> JasaUnverified() {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;

        var init = clientRepo.Clients
            .Where(c => c.JenisUsahaId != 3);

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection))) {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue)) {
            init = init.Where(a => a.ClientName.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init
            .Select(c => new {
                clientId = c.ClientId,
                clientName = c.ClientName,
                jenisId = c.JenisUsahaId,
                jenisUsaha = c.JenisUsahaId == 1 ? "Pengangkutan Sampah" : "Pengolahan Sampah",
                email = c.UserId,
                telp = c.Telp,
                clientGuid = c.ClientGuid
            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
    }
}