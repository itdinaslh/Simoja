using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Helpers;
using SharedLibrary.Repositories.Transportation;
using SharedLibrary.Entities.Transportation;

namespace Simoja.Controllers;

[Authorize(Roles = "SimojaAdmin, SysAdmin")]
public class JenisKendaraanController : Controller {
    private IKendaraan repo;

    public JenisKendaraanController(IKendaraan kRepo) {
        repo = kRepo;
    }

    [HttpGet("/master/kendaraan/jenis")]
    public IActionResult Index() {
        return View("~/Views/Master/JenisKendaraan/Index.cshtml");
    }

    [HttpGet("/master/kendaraan/jenis/create")]
    public IActionResult Create() => PartialView("~/Views/Master/JenisKendaraan/AddEdit.cshtml", new TipeKendaraan());

    [HttpGet("/master/kendaraan/jenis/edit")]
    public async Task<IActionResult> Edit(int jenisId) => PartialView("~/Views/Master/JenisKendaraan/AddEdit.cshtml", 
        await repo.TipeKendaraans.FirstOrDefaultAsync(j => j.TipeKendaraanID == jenisId)
    );

    [HttpPost("/master/kendaraan/jenis/save")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveDataAsync(TipeKendaraan model) {
        if (ModelState.IsValid) {
            await repo.SaveTipeAsync(model);
            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/JenisKendaraan/AddEdit.cshtml", model);
    }
}