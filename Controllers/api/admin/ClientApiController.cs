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
    private readonly IClient clientRepo;

    public ClientApiController(IClient cRepo) {
        clientRepo = cRepo;
    }

    [HttpPost("/api/admin/clients/unverified")]
    public async Task<IActionResult> Unverified() {
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
            .Where(c => c.IsVerified == false);

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection))) {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue)) {
            init = init.Where(a => a.ClientName.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init
            .Select(c => new {
                clientId = c.ClientID,
                clientName = c.ClientName,                
                //jenisUsaha = c.ClientJenis.First().JenisUsaha.NamaJenis == 1 ? "Pengangkutan Sampah" : "Pengolahan Sampah",
                email = c.UserId,
                telp = c.Telp,
                c.CreatedAt
            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
    }

    [HttpPost("/api/admin/jasa/angkutan")]
    public async Task<IActionResult> JasaAngkutTable()
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

        var init = clientRepo.Clients
            .Include(k => k.Kelurahan.Kecamatan.Kabupaten)
            .Where(c => c.JenisUsahas.Any(x => x.JenisUsahaID == 1) && c.IsVerified == true);

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.ClientName.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init
            .Select(c => new {
                clientID = c.ClientID,
                clientName = c.ClientName,                 
                email = c.UserId,
                telp = c.Telp,
                namaKabupaten = c.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten,
                c.CreatedAt
            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }
}