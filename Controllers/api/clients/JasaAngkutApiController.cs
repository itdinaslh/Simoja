using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace Simoja.Controllers.api;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "SimojaAngkut, SimojaAdmin")]
public class JasaAngkutApiController : Controller {
    private IKendaraan repo;
    private IClient clientRepo;
    private ILokasiAngkut lokasiRepo;

    public JasaAngkutApiController(IKendaraan kRepo, IClient cRepo, ILokasiAngkut lokRepo) {
        repo = kRepo; clientRepo = cRepo; lokasiRepo = lokRepo;
    }

    [HttpPost("/api/clients/jasa/pengangkutan/kendaraan/list")]
    public async Task<IActionResult> ListKendaraan() {
        #nullable disable
        string currentUser = User.Identity.Name;
        
        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientId
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
            .Where(k => k.ClientId == thisClient.ClientId);

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection))) {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue)) {
            init = init.Where(a => 
                a.NoPolisi.ToLower().Contains(searchValue.ToLower()) ||
                a.NoPintu.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init
            .Select(c => new {
                kendaraanId = c.KendaraanId,
                uniqueId = c.UniqueId,
                noPolisi = c.NoPolisi,
                noPintu = c.NoPintu,
                jenis = c.JenisKendaraan.NamaJenis,
                tahunPembuatan = c.TahunPembuatan,
                tglSTNK = c.TglSTNK,
                tglKIR = c.TglKIR
            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
    }

    [HttpPost("/api/clients/jasa/pengangkutan/lokasi-angkut/list")]
    public async Task<IActionResult> ListLokasiAngkut() {
        #nullable disable
        string currentUser = User.Identity.Name;
        
        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientId
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
            .Where(k => k.ClientId == thisClient.ClientId);

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
                LokasiAngkutId = c.LokasiAngkutId,
                uniqueId = c.UniqueId,
                namaLokasi = c.NamaLokasi,
                Kabupaten = c.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten,
                Kecamatan = c.Kelurahan.Kecamatan.NamaKecamatan,
                Kelurahan = c.Kelurahan.NamaKelurahan,
                tglAwalKontrak = c.TglAwalKontrak,
                tglAkhirKontrak = c.TglAkhirKontrak
            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
    }

    
}