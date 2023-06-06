using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace Simoja.Controllers.api;

[ApiController]
[Route("[controller]")]
public class JasaAngkutApiController : Controller {
    private readonly IKendaraan repo;
    private readonly IClient clientRepo;
    private readonly ILokasiAngkut lokasiRepo;
    

    public JasaAngkutApiController(IKendaraan kRepo, IClient cRepo, ILokasiAngkut lokRepo) {
        repo = kRepo; clientRepo = cRepo; lokasiRepo = lokRepo;
    }

    [HttpPost("/api/clients/pengangkutan/kendaraan/list")]
    public async Task<IActionResult> ListKendaraan()
    {
#nullable disable
        string currentUser = User.Identity.Name;

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

        var init = repo.Kendaraans
            .Where(k => k.ClientID == thisClient.ClientID);

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a =>
                a.NoPolisi.ToLower().Contains(searchValue.ToLower()) ||
                a.NoPintu.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init
            .Select(c => new
            {
                kendaraanId = c.KendaraanID,
                uniqueId = c.UniqueID,
                noPolisi = c.NoPolisi,
                noPintu = c.NoPintu,
                jenis = c.JenisKendaraan.NamaJenis,
                tahunPembuatan = c.TahunPembuatan,
                tglSTNK = c.TglSTNK.ToString("dd/MM/yyyy"),
                tglKIR = c.TglKIR.ToString("dd/MM/yyyy")
            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

        return Ok(jsonData);
    }

#nullable enable

    [HttpGet("/api/clients/pengangkutan/kendaraan/data")]
    public async Task<IActionResult> DataKendaraan(Guid id, string? search)
    {
        var data = await repo.Kendaraans
            .Where(x => x.IzinAngkuts.Any(i => i.IzinAngkutID == id))
            .Where(k => !String.IsNullOrEmpty(search) ?
                k.NoPolisi.ToLower().Contains(search.ToLower()) || k.NoPintu.ToLower().Contains(search.ToLower()) : true
            )
            .Select(x => new
            {
                x.KendaraanID,
                x.UniqueID,
                x.NoPolisi,
                x.NoPintu,
                jenis = x.JenisKendaraan.NamaJenis,
                tahunPembuatan = x.TahunPembuatan,
                tglSTNK = x.TglSTNK.ToString("dd/MM/yyyy"),
                tglKIR = x.TglKIR.ToString("dd/MM/yyyy")
            })
            .OrderByDescending(x => x.KendaraanID)
            .ToListAsync();

        return Ok(data);
    }

    [HttpPost("/api/clients/jasa/pengangkutan/lokasi-angkut/list")]
    public async Task<IActionResult> ListLokasiAngkut() {
        #nullable disable
        string currentUser = User.Identity.Name;
        
        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
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

        var init = lokasiRepo.LokasiAngkuts
            .Where(k => k.ClientID == thisClient.ClientID);

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection))) {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue)) {
            init = init.Where(a => 
                a.NamaLokasi.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init
            .Select(c => new {
                lokasiAngkutID = c.LokasiAngkutID,
                uniqueID = c.UniqueID,
                namaLokasi = c.NamaLokasi,
                kabupaten = c.Kawasan.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten,
                kecamatan = c.Kawasan.Kelurahan.Kecamatan.NamaKecamatan,
                kelurahan = c.Kawasan.Kelurahan.NamaKelurahan,
                tglAwalKontrak = c.TglAwalKontrak.ToString("dd/MM/yyyy"),
                tglAkhirKontrak = c.TglAkhirKontrak.ToString("dd/MM/yyyy")
            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = result};
        
        return Ok(jsonData);
    }

    [HttpPost("/api/clients/pengangkutan/izin/list")]
    [Authorize(Roles = "SysAdmin, PkmAngkut, PkmAngkutOlah")]
    public async Task<IActionResult> ListIzinAngkut()
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

        var init = clientRepo.IzinAngkuts
            .Where(k => k.ClientID == thisClient.ClientID);

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection))) {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue)) {
            init = init.Where(a => 
                a.NoIzinUsaha.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init
            .Select(c => new {
                izinAngkutID = c.IzinAngkutID,
                noIzinUsaha = c.NoIzinUsaha,
                jmlAngkutan = c.JmlAngkutan,
                tglTerbitIzin = c.TglTerbitIzin.ToString("dd/MM/yyyy"),
                tglAkhirIzin = c.TglAkhirIzin.ToString("dd/MM/yyyy")
            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = result};
        
        return Ok(jsonData);
    }


    [HttpGet("/api/clients/pengangkutan/kendaraan/nopol/search")]
    public async Task<IActionResult> SearchByNoPolisi(string? term)
    {
        string currentUser = User.Identity.Name;

        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new
            {
                c.ClientID
            })
            .FirstOrDefaultAsync();

        var data = await repo.Kendaraans
            .Where(x => x.ClientID == thisClient.ClientID)
            .Where(j => !String.IsNullOrEmpty(term) ?
                j.NoPolisi.ToLower().Contains(term.ToLower()) : true
            ).Select(jen => new {
                id = jen.KendaraanID,
                data = jen.NoPolisi
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/clients/pengangkutan/lokasi-angkut/search")]
    public async Task<IActionResult> SearchLokasiAngkut(string? term)
    {
        string currentUser = User.Identity.Name;

        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new
            {
                c.ClientID
            })
            .FirstOrDefaultAsync();

        var data = await lokasiRepo.LokasiAngkuts
            .Where(x => x.ClientID == thisClient.ClientID)
            .Where(j => !String.IsNullOrEmpty(term) ?
                j.NamaLokasi.ToLower().Contains(term.ToLower()) : true
            ).Select(jen => new {
                id = jen.LokasiAngkutID,
                data = jen.NamaLokasi
            }).ToListAsync();

        return Ok(data);
    }
}