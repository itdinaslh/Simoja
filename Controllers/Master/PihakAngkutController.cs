using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Repository;
using Simoja.Entity;
using Simoja.Helpers;

namespace Simoja.Controllers;

[Authorize]
public class PihakAngkutController : Controller {
    private IPihakAngkut repo;

    public PihakAngkutController(IPihakAngkut pRepo) {
        repo = pRepo;
    }

    [HttpGet("/master/kawasan/pihak-angkut")]
    public IActionResult Index() => View("~/Views/Master/PihakAngkut/Index.cshtml");

    [HttpGet("/master/kawasan/pihak-angkut/create")]
    public IActionResult Create() => PartialView("~/Views/Master/PihakAngkut/AddEdit.cshtml", new PihakAngkut());

    [HttpGet("/master/kawasan/pihak-angkut/edit")]
    public async Task<IActionResult> Edit(int pihakID) => PartialView("~/Views/Master/PihakAngkut/AddEdit.cshtml",
        await repo.PihakAngkuts.FirstOrDefaultAsync(j => j.PihakAngkutID == pihakID)
    );

    [HttpPost("/master/kawasan/pihak-angkut/save")]
    public async Task<IActionResult> SaveDataAsync(PihakAngkut pihak) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(pihak);
            return Json(Result.Success());
        }
        
        return PartialView("~/Views/Master/PihakAngkut/AddEdit.cshtml", pihak);
    }
}