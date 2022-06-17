using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Helpers;
using Simoja.Entity;
using System.Net;
using System.Drawing;


namespace Simoja.Controllers;

[Authorize]
public class ClientController : Controller {
    private IClient repo;

    public ClientController(IClient cRepo) {
        repo = cRepo;
    } 

    [HttpGet("/clients/register")]
    public async Task<IActionResult> Register() {
        #nullable disable
        Client myClient = await repo.Clients.Where(c => c.UserId == User.Identity.Name).FirstOrDefaultAsync();

        if (myClient is not null) {
            if (myClient.JenisUsahaId == 1) {
                return RedirectToAction("RegisterAngkut");
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

            await repo.SaveClientAsync(client);

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

        return View(new DetailAngkut());
    }

    [HttpPost("/clients/upload/izin")]
    public async Task<IActionResult> UploadIzin(List<IFormFile> files) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        foreach (var file in files) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/dokumen/izin/" + c.ClientGuid);            

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
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/dokumen/nib/" + c.ClientGuid);            

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

    [HttpGet("/clients/dokumen/izin")]
    public async Task<JsonResult> GetFolderIzinContents() {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/dokumen/izin/" + c.ClientGuid;

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
                FilePath = "/upload/dokumen/izin/" + c.ClientGuid + "/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    [HttpGet("/clients/dokumen/nib")]
    public async Task<JsonResult> GetFolderNIBContents() {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var folderPath = "wwwroot/upload/dokumen/nib/" + c.ClientGuid;

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
                FilePath = "/upload/dokumen/nib/" + c.ClientGuid + "/" + fileInfo.Name,
                FileSize = fileInfo.Length
            });
        }

        return new JsonResult(galleryItems) { StatusCode = 200 };
    }

    [HttpGet("/clients/dokumen/izin/delete")]
    public async Task<JsonResult> DeleteFileIzin(string file) {
        Client c = await repo.Clients.Where(m => m.UserId == User.Identity.Name).FirstOrDefaultAsync();

        var filePath = Path.Combine("wwwroot/upload/dokumen/izin/" + c.ClientGuid + "/" + file);

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

        var filePath = Path.Combine("wwwroot/upload/dokumen/nib/" + c.ClientGuid + "/" + file);

        try {
            System.IO.File.Delete(filePath);
        } catch {
            return new JsonResult(false) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        return new JsonResult(true) { StatusCode = (int)HttpStatusCode.OK };
    }
}