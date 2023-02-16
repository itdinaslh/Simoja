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
    private readonly IIzinAngkut izinRepo;

    public JasaAngkutApiController(IKendaraan kRepo, IClient cRepo, ILokasiAngkut lokRepo, IIzinAngkut iRepo) {
        repo = kRepo; clientRepo = cRepo; lokasiRepo = lokRepo; izinRepo = iRepo;
    }

    [HttpPost("/api/clients/jasa/pengangkutan/kendaraan/list")]
    public async Task<IActionResult> ListKendaraan() {
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

        var init = repo.Kendaraans
            .Where(k => k.ClientID == thisClient.ClientID);

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

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
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
                kabupaten = c.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten,
                kecamatan = c.Kelurahan.Kecamatan.NamaKecamatan,
                kelurahan = c.Kelurahan.NamaKelurahan,
                tglAwalKontrak = c.TglAwalKontrak.ToString("dd/MM/yyyy"),
                tglAkhirKontrak = c.TglAkhirKontrak.ToString("dd/MM/yyyy")
            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
    }

    [HttpPost("/api/clients/jasa/pengangkutan/izin/list")]
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
                izinAngkutId = c.IzinAngkutID,
                noIzinUsaha = c.NoIzinUsaha,
                jmlAngkutan = c.JmlAngkutan,
                tglAkhirIzin = c.TglAkhirIzin.ToString("dd/MM/yyyy")
            })
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
    }

    [HttpGet("/api/clients/total-izin")]
    public async Task<IActionResult> GetTotalIzin()
    {
        return NotFound();
    } 
}