﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Simoja.Repository;

namespace Simoja.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class KawasanApiController : ControllerBase
{
    private readonly IClient clientRepo;
    private readonly IKawasan kawasanRepo;

    public KawasanApiController(IClient clientRepo, IKawasan kawasanRepo)
    {
        this.clientRepo = clientRepo;
        this.kawasanRepo = kawasanRepo;
    }

    [HttpPost("/api/clients/usaha-kegiatan/kawasan/list")]
    public async Task<IActionResult> ListKawasan()
    {
#nullable disable
        string currentUser = User.Identity!.Name!;

        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new
            {
                c.ClientID
            })
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

        var init = kawasanRepo.Kawasans
            .Where(k => k.ClientID == thisClient!.ClientID);

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a =>
                a.NamaKawasan.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init
            .Select(c => new
            {
                kawasanID = c.KawasanID,
                noIzinUsaha = c.NoIzinUsaha,
                namaKawasan = c.NamaKawasan,
                lokasiIzin = c.LokasiIzin.NamaLokasi,
                tglTerbitIzin = c.TglTerbitIzin != null ? DateTime.Parse(c.TglTerbitIzin.ToString()).ToString("dd-MM-yyyy") : "-"

            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

        return Ok(jsonData);
    }
}
