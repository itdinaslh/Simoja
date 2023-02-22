using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Helpers;
using Simoja.Entity;
using System.Net;

namespace Simoja.Controllers;

[Authorize(Roles = "PkmAngkut")]
public class JasaAngkutController : Controller {
    private readonly IKendaraan vehicle;
    private readonly IClient clientRepo;
    private readonly ILokasiAngkut lokasiRepo;
    private readonly IIzinAngkut izinRepo;
    
    public JasaAngkutController(IKendaraan kRepo, IClient cRepo, ILokasiAngkut locRepo) {
        vehicle = kRepo; clientRepo = cRepo;
        lokasiRepo = locRepo;
    }

    [HttpGet("/dashboard/pengangkutan")]
    public IActionResult Dashboard() {
        return View();
    }

    [HttpGet("/clients/jasa/pengangkutan/izin")]
    public async Task<IActionResult> Perizinan()
    {
        Guid? curClient = await clientRepo.Clients.Where(c => c.UserId == User.Identity!.Name!.ToString())
            .Select(cli => cli.ClientID)
            .FirstOrDefaultAsync();        

        if (curClient != null)
        {
            //IzinAngkut? detail = await izinRepo.IzinAngkuts.Where(ang => ang.ClientID == curClient).FirstOrDefaultAsync();
            return View(new RegAngkutModel
            {
                IzinAngkut = new IzinAngkut
                {
                    DokumenIzin = "/upload"
                }
            });
        }

        return NotFound();
    }

    [HttpGet("/clients/jasa/pengangkutan/kendaraan")]
    public async Task<IActionResult> Kendaraan() {
        string? currentUser = User.Identity?.Name;

        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientID
            })
            .FirstOrDefaultAsync();

        #nullable disable
        var detail = await clientRepo.IzinAngkuts
            .Where(d => d.ClientID == thisClient.ClientID)
            .Select(d => new {
                d.JmlAngkutan
            }).FirstOrDefaultAsync();

        int jumlah = await vehicle.Kendaraans
            .Where(k => k.ClientID == thisClient.ClientID)
            .CountAsync();

        bool isForbid = true;

        if (detail != null)
        {
			if (jumlah < detail.JmlAngkutan)
				isForbid = false;
		}        

        return View(new KendaraanIndexVM {
            KendaranBerizin = detail is not null ? detail.JmlAngkutan : 0,
            KendaraanDiinput = jumlah,
            Forbid = isForbid
        });
    }

    [HttpGet("/clients/jasa/pengangkutan/kendaraan/create")]
    public IActionResult KendaraanCreate() {
        return View(new KendaraanCreateVM {
            Kendaraan = new Kendaraan()            
        });
    }

    [HttpGet("/clients/jasa/kendaraan/details")]
    public async Task<IActionResult> KendaraanDetails(Guid id)
    {
        Kendaraan truk = await vehicle.Kendaraans
            .Include(j => j.JenisKendaraan)
            .FirstOrDefaultAsync(x => x.UniqueID == id);

        return View(new KendaraanDetailVM
        {
            Kendaraan = truk
        });
    }

    [HttpPost("/clients/pengangkutan/upload/stnk")]
    public async Task<IActionResult> UploadSTNK(List<IFormFile> files, string id) {
        Client c = await clientRepo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientID + "/stnk/" + id);

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);            

            //get file extension
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);            

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create)) {
                await file.CopyToAsync(stream);
            }

        }

        return Json(Result.Success());
    }

    [HttpPost("/clients/pengangkutan/upload/kir")]
    public async Task<IActionResult> UploadKIR(List<IFormFile> files, string id) {
        Client c = await clientRepo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientID + "/kir/" + id);

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);            

            //get file extension
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);            

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create)) {
                await file.CopyToAsync(stream);
            }

        }

        return Json(Result.Success());
    }

    [HttpPost("/clients/pengangkutan/upload/foto-kendaraan")]
    public async Task<IActionResult> UploadFotoKendaraan(List<IFormFile> files, string id) {
        Client c = await clientRepo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientID + "/foto-kendaraan/" + id);

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);            

            //get file extension
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);            

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create)) {
                await file.CopyToAsync(stream);
            }
        }

        return Json(Result.Success());
    }

    [HttpPost("/clients/jasa/angkutan/kendaraan/store")]
    public async Task<IActionResult> SaveKendaraan(KendaraanCreateVM model) {
        var client = await clientRepo.Clients
            .Where(c => c.UserId == User.Identity.Name)
            .Select(c => new {
                c.ClientID                             
            })
            .FirstOrDefaultAsync();

        Guid uid = Guid.NewGuid();

        var kendaraan = await vehicle.Kendaraans
            .Where(v => v.KendaraanID == model.Kendaraan.KendaraanID)
            .FirstOrDefaultAsync();

        if (kendaraan is not null) {
            uid = kendaraan.UniqueID;
        } else {
            uid = model.UID;
        }

        model.Kendaraan.ClientID = client.ClientID;
        model.Kendaraan.DokumenSTNK = "/upload/" + client.ClientID + "/stnk/" + uid;
        model.Kendaraan.DokumenKIR = "/upload/" + client.ClientID + "/kir/" + uid;
        model.Kendaraan.FotoKendaraan = "/upload/" + client.ClientID + "/foto-kendaraan" + uid;
        model.Kendaraan.TglSTNK = DateOnly.ParseExact(model.TglBerlakuSTNK, "dd/MM/yyyy");
        model.Kendaraan.TglKIR = DateOnly.ParseExact(model.TglBerlakuKIR, "dd/MM/yyyy");
        model.Kendaraan.UniqueID = uid;

        if (ModelState.IsValid) {
            await vehicle.SaveKendaraanAsync(model.Kendaraan);

            return Json(Result.Success());
        }

        return View("~/Views/JasaAngkut/KendaraanCreate.cshtml", model);
    }

    // Lokasi Angkut

    [HttpGet("/clients/jasa/pengangkutan/lokasi-angkut")]
    public IActionResult LokasiAngkut() => View();

    [HttpPost("/clients/pengangkutan/upload/lokasi-angkut")]
    public async Task<IActionResult> UploadLokasi(List<IFormFile> files, string id) {
        Client c = await clientRepo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientID + "/lokasi-angkut/" + id);

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);            

            //get file extension
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);            

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create)) {
                await file.CopyToAsync(stream);
            }

        }

        return Json(Result.Success());
    }

    [HttpGet("/clients/jasa/pengangkutan/lokasi-angkut/create")]
    public IActionResult LokasiAngkutCreate() {        
        #nullable disable        

        return View(new LokasiAngkutCreateVM {
            LokasiAngkut = new LokasiAngkut()
        });
    }

    [HttpPost("/clients/jasa/pengangkutan/lokasi-angkut/store")]
    public async Task<IActionResult> LokasiAngkutSave(LokasiAngkutCreateVM model) {
        string currentUser = User.Identity.Name;

        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientID                
            }).FirstOrDefaultAsync();

        Guid uid = Guid.Empty;

        var lokasi = await lokasiRepo.LokasiAngkuts
            .Where(l => l.LokasiAngkutID == model.LokasiAngkut.LokasiAngkutID)
            .FirstOrDefaultAsync();

        if (lokasi is not null) {
            uid = model.LokasiAngkut.UniqueID;
        } else {
            uid = model.UID;
        }

        model.LokasiAngkut.ClientID = thisClient.ClientID;        
        model.LokasiAngkut.DokumenPath = "/upload/" + thisClient.ClientID + "/lokasi-angkut/" + uid;
        model.LokasiAngkut.TglAwalKontrak = DateOnly.ParseExact(model.TglAwal, "dd/MM/yyyy");
        model.LokasiAngkut.TglAkhirKontrak = DateOnly.ParseExact(model.TglAkhir, "dd/MM/yyyy");

        model.LokasiAngkut.UniqueID = uid;

        if (ModelState.IsValid) {
            await lokasiRepo.SaveLokasiAngkutAsync(model.LokasiAngkut);

            return Json(Result.Success());
        }

        return View("~/Views/JasaAngkut/LokasiAngkutCreate.cshtml", model);
    }

}