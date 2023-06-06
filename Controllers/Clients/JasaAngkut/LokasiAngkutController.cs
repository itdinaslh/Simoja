using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simoja.Entity;
using Simoja.Helpers;
using Simoja.Models;
using Simoja.Repository;
using Microsoft.EntityFrameworkCore;

namespace Simoja.Controllers;


[Authorize(Roles = "PkmAngkut")]
public class LokasiAngkutController : Controller
{
    private readonly ILokasiAngkut repo;
    private readonly IClient clientRepo;

    public LokasiAngkutController(ILokasiAngkut repo, IClient clientRepo) {
        this.repo = repo;
        this.clientRepo = clientRepo;
    } 

    [HttpGet("/clients/pengangkutan/lokasi-angkut")]
    public IActionResult Index() => View("~/Views/Client/JasaAngkut/LokasiAngkut.cshtml");

    [HttpGet("/clients/pengangkutan/lokasi-angkut/create")]
    public IActionResult Create()
    {
        return View("~/Views/Client/JasaAngkut/LokasiAngkutCreate.cshtml" ,new LokasiAngkutCreateVM
        {
            LokasiAngkut = new LokasiAngkut()
        });
    }

    [HttpPost("/clients/pengangkutan/lokasi-angkut/create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Store(LokasiAngkutCreateVM model)
    {
        var client = await clientRepo.Clients
            .Where(c => c.UserId == User.Identity!.Name)
            .Select(c => new {
                c.ClientID
            })
            .FirstOrDefaultAsync();

        model.LokasiAngkut!.ClientID = client!.ClientID;        
        model.LokasiAngkut.UniqueID = Guid.NewGuid();
        

        if (ModelState.IsValid)
        {
            model.LokasiAngkut.TglAwalKontrak = DateOnly.ParseExact(model.TglAwal, "dd/MM/yyyy");
            model.LokasiAngkut.TglAkhirKontrak = DateOnly.ParseExact(model.TglAkhir, "dd/MM/yyyy");
            model.LokasiAngkut.DokumenPath = await Upload.LokasiAngkut(model.FileDokumen!, client!.ClientID.ToString());

            await repo.SaveLokasiAngkutAsync(model.LokasiAngkut);

            return RedirectToAction("Index");
        }

        return View("~/Views/Client/JasaAngkut/LokasiAngkutCreate.cshtml", model);
    }
}
