using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simoja.Entity;
using Simoja.Repository;
using System.Data;
using System.Linq.Dynamic.Core;

namespace Simoja.Controllers.api.clients
{
    [Route("api/[controller]")]
    [ApiController]    
    public class JasaOlahApiController : ControllerBase
    {
        private readonly IClient clientRepo;

        public JasaOlahApiController(IClient clientRepo)
        {
            this.clientRepo = clientRepo;
        }

#nullable disable

        [HttpPost("/api/clients/jasa/pengolahan/izin/list")]
        [Authorize(Roles = "PkmOlah")]
        public async Task<IActionResult> ListIzinOlah()
        {
            string currentUser = User.Identity.Name;

            Client thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
                .FirstOrDefaultAsync();

            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var init = clientRepo.IzinOlahs
                .Where(k => k.ClientID == thisClient.ClientID);

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                init = init.OrderBy(sortColumn + " " + sortColumnDirection);
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                init = init.Where(a =>
                    a.NoIzinUsaha.ToLower().Contains(searchValue.ToLower())
                );
            }

            recordsTotal = init.Count();

            var result = await init
                .Select(c => new {
                    izinOlahId = c.IzinOlahID,
                    noIzinUsaha = c.NoIzinUsaha,                    
                    tglAkhirIzin = c.TglAkhirIzin.ToString("dd/MM/yyyy")
                })
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

            return Ok(jsonData);
        }
    }
}
