using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Helpers;
using Simoja.Entity;
using System.Net;

namespace Simoja.Controllers;

[Authorize]
public class ClientController : Controller {
    private IClient repo;

    public ClientController(IClient cRepo) {
        repo = cRepo;
    } 

    [HttpGet("/clients/waiting")]
    public IActionResult Waiting() {
        return View();
    }

    [HttpGet("/clients/register")]
    public async Task<IActionResult> Register() {
        #nullable disable
        Client myClient = await repo.Clients.Where(c => c.UserId == User.Identity.Name).FirstOrDefaultAsync();

        if (myClient is not null) {
            if (myClient.JenisUsahaId == 1) {
                return RedirectToAction("RegisterAngkut");
            } else if (myClient.JenisUsahaId == 2) {
                return RedirectToAction("RegisterOlah");
            } else {
                return RedirectToAction("RegisterUsaha");
            }
        }

        return View(new Client());
    }

    [HttpPost("/clients/register")]
    public async Task<IActionResult> Register(Client client) {
        if(ModelState.IsValid) {
            int theID = 1;
            string action = "";

            if (User.IsInRole("SimojaAngkut")) {
                theID = 1;
                action = "RegisterAngkut";
            } else if (User.IsInRole("SimojaOlah")) {
                theID = 2;
                action = "RegisterOlah";
            } else {
                theID = 3;
                action = "RegisterUsaha";
            }

            client.JenisUsahaId = theID;

            try {
                await repo.SaveClientAsync(client);                
            } catch {
                return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };               
            }

            return RedirectToAction(action);
        }

        return View(client);
    }

    [HttpGet("/clients/register/pengangkutan")]
    public async Task<IActionResult> RegisterAngkut() {
        #nullable disable
        int curClient = await repo.Clients.Where(c => c.UserId == User.Identity.Name.ToString())
            .Select(cli => cli.ClientId)
            .FirstOrDefaultAsync();

        DetailAngkut detail = await repo.DetailAngkuts.Where(ang => ang.ClientId == curClient).FirstOrDefaultAsync();

        if (detail != null) {
            return View(detail);
        }

        return View(new RegAngkutModel {
            DetailAngkut = new DetailAngkut {
                DokumenIzinPath = "/upload",
                NIBPath = "/upload"
            },
            TglAwal = DateTime.Now.ToString("dd/MM/yyyy"),
            TglAkhir = DateTime.Now.ToString("dd/MM/yyyy")
        });
    }

    [HttpGet("/clients/register/pengolahan")]
    public async Task<IActionResult> RegisterOlah() {
        int curClient = await repo.Clients.Where(c => c.UserId == User.Identity.Name.ToString())
            .Select(ci => ci.ClientId)
            .FirstOrDefaultAsync();

        DetailOlah detail = await repo.DetailOlahs.Where(o => o.ClientId == curClient).FirstOrDefaultAsync();

        if (detail is not null) {
            return View(detail);
        }

        return View(new DetailOlah());
    }

    [HttpGet("/clients/register/usaha-kegiatan")]
    public async Task<IActionResult> RegisterUsaha() {
        int curClient = await repo.Clients.Where(c => c.UserId == User.Identity.Name.ToString())
            .Select(ci => ci.ClientId)
            .FirstOrDefaultAsync();

        DetailKawasan detail = await repo.DetailKawasans.Where(o => o.ClientId == curClient).FirstOrDefaultAsync();

        if (detail is not null) {
            return View(detail);
        }

        return View(new DetailKawasan());
    }

    // Upload Function

    [HttpPost("/clients/upload/izin")]
    public async Task<IActionResult> UploadIzin(List<IFormFile> files) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientGuid + "/izin");            

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

    [HttpPost("/clients/upload/nib")]
    public async Task<IActionResult> UploadNIB(List<IFormFile> files) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientGuid  + "/nib");            

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

    [HttpPost("/clients/upload/wadah")]
    public async Task<IActionResult> UploadWadah(List<IFormFile> files) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientGuid  + "/wadah");            

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

    [HttpPost("/clients/upload/tps")]
    public async Task<IActionResult> UploadTPS(List<IFormFile> files) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientGuid  + "/tps");            

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

    [HttpPost("/clients/upload/pengolahan")]
    public async Task<IActionResult> UploadPengolahan(List<IFormFile> files) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientGuid  + "/pengolahan");            

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

    // Get Folder Contents For Dropzone Preview

    [HttpGet("/clients/dokumen/izin")]
    public async Task<JsonResult> GetFolderIzinContents() {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/" + c.ClientGuid + "/izin";

        if (!Directory.Exists(folderPath))
            return new JsonResult("Folder not exists!") { StatusCode = (int)HttpStatusCode.NotFound };

        var folderItems = Directory.GetFiles(folderPath);

        if (folderItems.Length == 0)
            return new JsonResult("Folder is empty!") { StatusCode = (int)HttpStatusCode.NoContent };

        var galleryItems = new List<FileItem>();

        foreach (var file in folderItems)
        {
            var fileInfo = new FileInfo(file);
            galleryItems.Add(new FileItem
            {
                Name = fileInfo.Name,
                FilePath = "/upload/" + c.ClientGuid + "/izin/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    [HttpGet("/clients/dokumen/nib")]
    public async Task<JsonResult> GetFolderNIBContents() {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/" + c.ClientGuid + "/nib";

        if (!Directory.Exists(folderPath))
            return new JsonResult("Folder not exists!") { StatusCode = (int)HttpStatusCode.NotFound };

        var folderItems = Directory.GetFiles(folderPath);

        if (folderItems.Length == 0)
            return new JsonResult("Folder is empty!") { StatusCode = (int)HttpStatusCode.NoContent };

        var galleryItems = new List<FileItem>();

        foreach (var file in folderItems)
        {
            var fileInfo = new FileInfo(file);
            galleryItems.Add(new FileItem
            {
                Name = fileInfo.Name,
                FilePath = "/upload/" + c.ClientGuid + "/nib/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    [HttpGet("/clients/dokumen/wadah")]
    public async Task<JsonResult> GetFolderWadahContents() {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/" + c.ClientGuid + "/wadah";

        if (!Directory.Exists(folderPath))
            return new JsonResult("Folder not exists!") { StatusCode = (int)HttpStatusCode.NotFound };

        var folderItems = Directory.GetFiles(folderPath);

        if (folderItems.Length == 0)
            return new JsonResult("Folder is empty!") { StatusCode = (int)HttpStatusCode.NoContent };

        var galleryItems = new List<FileItem>();

        foreach (var file in folderItems)
        {
            var fileInfo = new FileInfo(file);
            galleryItems.Add(new FileItem
            {
                Name = fileInfo.Name,
                FilePath = "/upload/" + c.ClientGuid + "/wadah/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    [HttpGet("/clients/dokumen/tps")]
    public async Task<JsonResult> GetFolderTPSContents() {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/" + c.ClientGuid + "/tps";

        if (!Directory.Exists(folderPath))
            return new JsonResult("Folder not exists!") { StatusCode = (int)HttpStatusCode.NotFound };

        var folderItems = Directory.GetFiles(folderPath);

        if (folderItems.Length == 0)
            return new JsonResult("Folder is empty!") { StatusCode = (int)HttpStatusCode.NoContent };

        var galleryItems = new List<FileItem>();

        foreach (var file in folderItems)
        {
            var fileInfo = new FileInfo(file);
            galleryItems.Add(new FileItem
            {
                Name = fileInfo.Name,
                FilePath = "/upload/" + c.ClientGuid + "/tps/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    [HttpGet("/clients/dokumen/pengolahan")]
    public async Task<JsonResult> GetFolderPengolahanContents() {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/" + c.ClientGuid + "/pengolahan";

        if (!Directory.Exists(folderPath))
            return new JsonResult("Folder not exists!") { StatusCode = (int)HttpStatusCode.NotFound };

        var folderItems = Directory.GetFiles(folderPath);

        if (folderItems.Length == 0)
            return new JsonResult("Folder is empty!") { StatusCode = (int)HttpStatusCode.NoContent };

        var galleryItems = new List<FileItem>();

        foreach (var file in folderItems)
        {
            var fileInfo = new FileInfo(file);
            galleryItems.Add(new FileItem
            {
                Name = fileInfo.Name,
                FilePath = "/upload/" + c.ClientGuid + "/pengolahan/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    // Dropzone Delete Function
    [HttpGet("/clients/dokumen/izin/delete")]
    public async Task<JsonResult> DeleteFileIzin(string file) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var filePath = Path.Combine("wwwroot/upload/" + c.ClientGuid + "/izin/" + file);

        try {
            System.IO.File.Delete(filePath);
        } catch {
            return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        return new JsonResult(true) { StatusCode = (int)HttpStatusCode.OK };
    }

    [HttpGet("/clients/dokumen/nib/delete")]
    public async Task<JsonResult> DeleteFileNIB(string file) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var filePath = Path.Combine("wwwroot/upload/" + c.ClientGuid + "/nib/" + file);

        try {
            System.IO.File.Delete(filePath);
        } catch {
            return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        return new JsonResult(true) { StatusCode = (int)HttpStatusCode.OK };
    }

    [HttpGet("/clients/dokumen/wadah/delete")]
    public async Task<JsonResult> DeleteFileWadah(string file) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var filePath = Path.Combine("wwwroot/upload/" + c.ClientGuid + "/wadah/" + file);

        try {
            System.IO.File.Delete(filePath);
        } catch {
            return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        return new JsonResult(true) { StatusCode = (int)HttpStatusCode.OK };
    }

    [HttpGet("/clients/dokumen/tps/delete")]
    public async Task<JsonResult> DeleteFileTPS(string file) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var filePath = Path.Combine("wwwroot/upload/" + c.ClientGuid + "/tps/" + file);

        try {
            System.IO.File.Delete(filePath);
        } catch {
            return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        return new JsonResult(true) { StatusCode = (int)HttpStatusCode.OK };
    }

    [HttpGet("/clients/dokumen/pengolahan/delete")]
    public async Task<JsonResult> DeleteFilePengolahan(string file) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var filePath = Path.Combine("wwwroot/upload/" + c.ClientGuid + "/pengolahan/" + file);

        try {
            System.IO.File.Delete(filePath);
        } catch {
            return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        return new JsonResult(true) { StatusCode = (int)HttpStatusCode.OK };
    }

    [HttpPost("/clients/register/angkut/save")]
    // [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveDetailAngkut(RegAngkutModel model) {
        Client client = await repo.Clients.Where(c => c.UserId == User.Identity.Name).FirstOrDefaultAsync();

        model.DetailAngkut.ClientId = client.ClientId;
        model.DetailAngkut.DokumenIzinPath = "/upload/" + client.ClientGuid + "/izin";
        model.DetailAngkut.NIBPath = "/upload/" + client.ClientGuid + "/nib";
        model.DetailAngkut.TglTerbitIzin = DateOnly.ParseExact(model.TglAwal, "dd/MM/yyyy");
        model.DetailAngkut.TglAkhirIzin = DateOnly.ParseExact(model.TglAkhir, "dd/MM/yyyy");

        if (ModelState.IsValid) {
            await repo.SaveDetailAngkut(model.DetailAngkut);

            return RedirectToAction("Waiting");
        }

        return View("~/Views/Client/RegisterAngkut.cshtml", model);
    }
}