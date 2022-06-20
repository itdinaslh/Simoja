using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Repository;
using Simoja.Entity;
using Simoja.Helpers;

namespace Simoja.Controllers;

[Authorize(Roles = "SimojaAdmin, SystemAdmin")]
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
    public IActionResult Create() => PartialView("~/Views/Master/JenisKendaraan/AddEdit.cshtml", new JenisKendaraan());

    [HttpGet("/master/kendaraan/jenis/edit")]
    public async Task<IActionResult> Edit(int jenisId) => PartialView("~/Views/Master/JenisKendaraan/AddEdit.cshtml", 
        await repo.JenisKendaraans.FirstOrDefaultAsync(j => j.JenisKendaraanId == jenisId)
    );

    [HttpPost("/master/kendaraan/jenis/save")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveDataAsync(JenisKendaraan model) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(model);
            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/JenisKendaraan/AddEdit.cshtml", model);
    }
}