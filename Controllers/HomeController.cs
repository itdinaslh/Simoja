using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Entity;

namespace Simoja.Controllers;

[Authorize]
public class HomeController : Controller
{
    private IClient repo;    

    public HomeController(IClient cRepo)
    {
        repo = cRepo;
    }

    [HttpGet("/dashboard")]
    public async Task<IActionResult> Index()
    {
        if (User.IsInRole("SystemAdmin") || User.IsInRole("SimojaAdmin")) {
            return View();
        }

        string? currentUser = User.Identity?.Name;

        var thisClient = await repo.Clients.Where(c => c.UserId == currentUser)
            .Select(c => new {
                c.ClientId,
                c.JenisUsahaId,
                c.IsVerified
            })
            .FirstOrDefaultAsync();

        if (thisClient is null) {
            return RedirectToAction("Register", "Client");
        } else if (thisClient.JenisUsahaId == 1) {            
            var data = await repo.DetailAngkuts.Where(d => d.ClientId == thisClient.ClientId).FirstOrDefaultAsync();
            if (data is not null) {
                if (thisClient.IsVerified)
                    return RedirectToAction("IndexAngkut");

                return RedirectToAction("Waiting", "Client");                
            } else {
                return RedirectToAction("RegisterAngkut", "Client");
            }
        } else {
            
        }

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult IndexAngkut() {
        return View();
    }

}
