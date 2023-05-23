using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Helpers;
using Simoja.Entity;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Simoja.Controllers;

[Authorize]
public class ClientController : Controller {
    private readonly IClient repo;

    public ClientController(IClient cRepo) {
        repo = cRepo;
    } 

    [HttpGet("/clients/waiting")]
    public IActionResult Waiting() {
        return View();
    }

    [HttpGet("/clients/register")]
    [Authorize(Roles = "PkmAngkut, PkmOlah, PkmUsaha")]
    public async Task<IActionResult> Register() {
#nullable disable
        string uid = ((ClaimsIdentity)User.Identity!).Claims.Where(c => c.Type == "sub").Select(c => c.Value).SingleOrDefault();
        Client client = await repo.Clients.FirstOrDefaultAsync(x => x.ClientID.ToString() == uid);

        if (client == null)
            return View(new RegisterVM
            {
                Client = new Client
                {
                    ClientID = Guid.Parse(uid)
                }
            });

        if (User.IsInRole("PkmAngkut"))
            return RedirectToAction("RegisterAngkut");
        else if (User.IsInRole("PkmOlah"))
            return RedirectToAction("RegisterOlah");
        else if (User.IsInRole("PkmAngkutOlah"))
            return NotFound();
        else
            return RedirectToAction("RegisterUsaha");

    }

    [HttpPost("/clients/register")]
    [Authorize(Roles = "PkmAngkut, PkmOlah, PkmUsaha")]
    public async Task<IActionResult> Register(RegisterVM model) {
        string uid = ((ClaimsIdentity)User.Identity!).Claims.Where(c => c.Type == "sub").Select(c => c.Value).SingleOrDefault();

        //model.Client.ClientID = Guid.Parse(uid);

        if (ModelState.IsValid)
        {

            int theID = 1;
            //string action = "";

            if (User.IsInRole("PkmAngkut"))
            {
                theID = 1;
                //action = "RegisterAngkut";
            }
            else if (User.IsInRole("PkmOlah"))
            {
                theID = 2;
                //action = "RegisterOlah";
            }           
            else
            {
                theID = 3;
                //action = "RegisterUsaha";
            }

            model.Client.JenisUsahaID = theID;

            string fileNameKTP = await Upload.KTP(model.FileKTP, uid);
            string fileNameNPWP = await Upload.NPWP(model.FileNPWP, uid);
            string fileNameNIB = "";

            if (model.FileNIB is not null)
            {
                fileNameNIB = await Upload.NIB(model.FileNIB, uid);
            }

            model.Client.DokumenKTP = fileNameKTP;
            model.Client.DokumenNIB = fileNameNIB;
            model.Client.DokumenNPWP = fileNameNPWP;			

            try
            {
				await repo.SaveClientAsync(model);
			}
            catch
            {
                return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

            return RedirectToAction("Index", "Home");
        }

        return View(model);


    }

    [HttpGet("/clients/register/pengangkutan")]
    [Authorize(Roles = "PkmAngkut")]
    public async Task<IActionResult> RegisterAngkut() {
        #nullable enable
        Guid? curClient = await repo.Clients.Where(c => c.UserId == User.Identity!.Name!.ToString())
            .Select(cli => cli.ClientID)
            .FirstOrDefaultAsync();

        IzinAngkut? detail = await repo.IzinAngkuts.Where(ang => ang.ClientID == curClient).FirstOrDefaultAsync();

        if (curClient != null)
        {
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

    [HttpGet("/clients/register/pengolahan")]
    [Authorize(Roles = "PkmOlah")]
    public IActionResult RegisterOlah() {
        return View(new RegOlahModel{
            IzinOlah = new IzinOlah(),
            TglAwal = String.Empty,
            TglAkhir = String.Empty
        });
    }

    //[HttpGet("/clients/register/usaha-kegiatan")]
    //[Authorize(Roles = "PkmUsaha")]
    //public async Task<IActionResult> RegisterUsaha() {
    //    Guid? curClient = await repo.Clients.Where(c => c.UserId == User.Identity!.Name!.ToString())
    //        .Select(ci => ci.ClientID)
    //        .FirstOrDefaultAsync();

    //    IzinKawasan? detail = await repo.IzinKawasans.Where(o => o.ClientID == curClient).FirstOrDefaultAsync();

    //    if (curClient is not null) {
    //        return View(detail);
    //    }

    //    return View(new IzinKawasan());
    //}

    // Verifikasi Client

    [HttpPost("/api/admin/clients/verifikasi")]    
    public async Task<IActionResult> Verifikasi()
    {
        var data = Request.Form["theID"].FirstOrDefault();

        Client? client = await repo.Clients.FirstOrDefaultAsync(x => x.ClientID == Guid.Parse(data!));


        if (client is not null)
        {
            await repo.VerifikasiClient(client);

            return Json(Result.Success());
        }

        return NotFound();
    }

    // Upload Function
#nullable disable
    [HttpPost("/clients/upload/izin")]
    public async Task<IActionResult> UploadIzin(List<IFormFile> files, string id)
    {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientID + "/izin/" + id);

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await file.CopyToAsync(stream);

        }

        return Json(Result.Success());
    }

    [HttpPost("/clients/upload/nib")]
    public async Task<IActionResult> UploadNIB(List<IFormFile> files)
    {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientID + "/nib");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await file.CopyToAsync(stream);

        }

        return Json(Result.Success());
    }

    [HttpPost("/clients/upload/wadah")]
    public async Task<IActionResult> UploadWadah(List<IFormFile> files)
    {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientID + "/wadah");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await file.CopyToAsync(stream);

        }

        return Json(Result.Success());
    }

    [HttpPost("/clients/upload/tps")]
    public async Task<IActionResult> UploadTPS(List<IFormFile> files)
    {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientID + "/tps");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await file.CopyToAsync(stream);

        }

        return Json(Result.Success());
    }

    [HttpPost("/clients/upload/pengolahan")]
    public async Task<IActionResult> UploadPengolahan(List<IFormFile> files)
    {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/" + c.ClientID + "/pengolahan");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await file.CopyToAsync(stream);

        }

        return Json(Result.Success());
    }

    // Get Folder Contents For Dropzone Preview

    [HttpGet("/clients/dokumen/izin")]
    public async Task<JsonResult> GetFolderIzinContents(string id)
    {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/" + c.ClientID + "/izin/" + id;

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
                FilePath = "/upload/" + c.ClientID + "/izin/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    [HttpGet("/clients/dokumen/nib")]
    public async Task<JsonResult> GetFolderNIBContents()
    {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/" + c.ClientID + "/nib";

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
                FilePath = "/upload/" + c.ClientID + "/nib/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    [HttpGet("/clients/dokumen/wadah")]
    public async Task<JsonResult> GetFolderWadahContents()
    {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/" + c.ClientID + "/wadah";

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
                FilePath = "/upload/" + c.ClientID + "/wadah/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    [HttpGet("/clients/dokumen/tps")]
    public async Task<JsonResult> GetFolderTPSContents()
    {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/" + c.ClientID + "/tps";

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
                FilePath = "/upload/" + c.ClientID + "/tps/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    [HttpGet("/clients/dokumen/pengolahan")]
    public async Task<JsonResult> GetFolderPengolahanContents()
    {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/" + c.ClientID + "/pengolahan";

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
                FilePath = "/upload/" + c.ClientID + "/pengolahan/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    // Dropzone Delete Function
    [HttpGet("/clients/dokumen/izin/delete")]
    public async Task<JsonResult> DeleteFileIzin(string id, string file) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var filePath = Path.Combine("wwwroot/upload/" + c.ClientID + "/izin/" + id + "/" + file);

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

        var filePath = Path.Combine("wwwroot/upload/" + c.ClientID + "/nib/" + file);

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

        var filePath = Path.Combine("wwwroot/upload/" + c.ClientID + "/wadah/" + file);

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

        var filePath = Path.Combine("wwwroot/upload/" + c.ClientID + "/tps/" + file);

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

        var filePath = Path.Combine("wwwroot/upload/" + c.ClientID + "/pengolahan/" + file);

        try {
            System.IO.File.Delete(filePath);
        } catch {
            return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        return new JsonResult(true) { StatusCode = (int)HttpStatusCode.OK };
    }    

    [HttpPost("/clients/register/olah/save")]
    // [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveIzinOlah(RegOlahModel model) {
        Client client = await repo.Clients.Where(c => c.UserId == User.Identity.Name).FirstOrDefaultAsync();

        model.IzinOlah.ClientID = client.ClientID;
        model.IzinOlah.DokumenIzin = "/upload/" + client.ClientID + "/izin";        
        model.IzinOlah.TglTerbitIzin = DateOnly.ParseExact(model.TglAwal, "dd/MM/yyyy");
        model.IzinOlah.TglAkhirIzin = DateOnly.ParseExact(model.TglAkhir, "dd/MM/yyyy");

        if (ModelState.IsValid) {
            await repo.SaveIzinOlah(model.IzinOlah);

            return Json(Result.Success());
        }

        return View("~/Views/Client/RegisterOlah.cshtml", model);
    }
}