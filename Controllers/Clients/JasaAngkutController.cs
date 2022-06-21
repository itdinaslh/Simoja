using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Helpers;
using Simoja.Entity;
using System.Net;

namespace Simoja.Controllers;

[Authorize(Roles = "SimojaAngkut")]
public class JasaAngkutController : Controller {
    private IKendaraan vehicle;
    private IClient clientRepo;
    private ILokasiAngkut lokasiRepo;
    
    public JasaAngkutController(IKendaraan kRepo, IClient cRepo, ILokasiAngkut locRepo) {
        vehicle = kRepo; clientRepo = cRepo;
        lokasiRepo = locRepo;
    }

    [HttpGet("/dashboard/pengangkutan")]
    public IActionResult Dashboard() {
        return View();
    }

    [HttpGet("/clients/jasa/pengangkutan/kendaraan")]
    public async Task<IActionResult> Kendaraan() {
        string? currentUser = User.Identity?.Name;

        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientId
            })
            .FirstOrDefaultAsync();

        #nullable disable
        var detail = await clientRepo.DetailAngkuts
            .Where(d => d.ClientId == thisClient.ClientId)
            .Select(d => new {
                d.JmlAngkutan
            }).FirstOrDefaultAsync();

        int jumlah = await vehicle.Kendaraans
            .Where(k => k.ClientId == thisClient.ClientId)
            .CountAsync();

        bool isForbid = true;

        if (jumlah < detail.JmlAngkutan)
            isForbid = false;

        return View(new KendaraanIndexVM {
            KendaranBerizin = detail.JmlAngkutan,
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

    [HttpPost("/clients/pengangkutan/upload/stnk")]
    public async Task<IActionResult> UploadSTNK(List<IFormFile> files, string id) {
        Client c = await clientRepo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientGuid + "/stnk/" + id);

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
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientGuid + "/kir/" + id);

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
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientGuid + "/foto-kendaraan/" + id);

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
                c.ClientId,
                c.ClientGuid             
            })
            .FirstOrDefaultAsync();

        Guid uid = Guid.NewGuid();

        var kendaraan = await vehicle.Kendaraans
            .Where(v => v.KendaraanId == model.Kendaraan.KendaraanId)
            .FirstOrDefaultAsync();

        if (kendaraan is not null) {
            uid = kendaraan.UniqueId;
        } else {
            uid = model.UID;
        }

        model.Kendaraan.ClientId = client.ClientId;
        model.Kendaraan.DokumenSTNK = "/upload/" + client.ClientGuid + "/stnk/" + uid;
        model.Kendaraan.DokumenKIR = "/upload/" + client.ClientGuid + "/kir/" + uid;
        model.Kendaraan.FotoKendaraan = "/upload/" + client.ClientGuid + "/foto-kendaraan" + uid;
        model.Kendaraan.TglSTNK = DateOnly.ParseExact(model.TglBerlakuSTNK, "dd/MM/yyyy");
        model.Kendaraan.TglKIR = DateOnly.ParseExact(model.TglBerlakuKIR, "dd/MM/yyyy");
        model.Kendaraan.UniqueId = uid;

        if (ModelState.IsValid) {
            await vehicle.SaveKendaraanAsync(model.Kendaraan);

            return Json(Result.Success());
        }

        return View("~/Views/JasaAngkut/KendaraanCreate.cshtml", model);
    }

    // Lokasi Angkut

    [HttpGet("/clients/jasa/pengangkutan/lokasi-angkut")]
    public IActionResult LokasiAngkut() => View();

    [HttpGet("/clients/jasa/pengangkutan/lokasi/create")]
    public async Task<IActionResult> LokasiAngkutCreate() {        
        #nullable disable

        string currentUser = User.Identity.Name;

        var thisClient = await clientRepo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientId
            }).FirstOrDefaultAsync();

        return View(new LokasiAngkutCreateVM {
            LokasiAngkut = new LokasiAngkut {
                ClientId = thisClient.ClientId
            }
        });
    }

    // [HttpPost("/clients/jasa/pengangkutan/lokasi/store")]
    // public async Task<IActionResult> LokasiAngkutSave(LokasiAngkutCreateVM model) {

    // }
}