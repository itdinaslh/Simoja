using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Repository;
using Simoja.Entity;
using Simoja.Helpers;

namespace Simoja.Controllers;

[Authorize]
public class StatusKelolaController : Controller {
    private IStatusKelola repo;

    public StatusKelolaController(IStatusKelola sRepo) {
        repo = sRepo;
    }

    [HttpGet("/master/kawasan/status")]
    public IActionResult Index() => View("~/Views/Master/StatusKelola/Index.cshtml");

    [HttpGet("/master/kawasan/status/create")]
    public IActionResult Create() => PartialView("~/Views/Master/StatusKelola/AddEdit.cshtml", new StatusKelola());

    [HttpGet("/master/kawasan/status/edit")]
    public async Task<IActionResult> Edit(int statusID) => PartialView("~/Views/Master/StatusKelola/AddEdit.cshtml",
        await repo.StatusKelolas.FirstOrDefaultAsync(j => j.StatusKelolaID == statusID)
    );

    [HttpPost("/master/kawasan/status/save")]
    public async Task<IActionResult> SaveDataAsync(StatusKelola jenis) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(jenis);
            return Json(Result.Success());
        }
        
        return PartialView("~/Views/Master/StatusKelola/AddEdit.cshtml", jenis);
    }
}