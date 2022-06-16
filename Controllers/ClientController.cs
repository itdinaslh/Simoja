using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Entity;

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

    [HttpGet("/clients/upload/izin")]
    public async Task UploadIzin(List<IFormFile> files) {
        foreach (var file in files) {
            // get file names uploaded
            var filename = file.TempFileName();

            if (file.Length > 0) {
                using (var stream = new FileStream($"wwwroot\\upload\\{filename}", FileMode.Create)) {
                    await file.CopyToAsync(stream);
                }
            }
        }
    }
}