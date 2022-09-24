using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Repository;
using Simoja.Entity;
using Simoja.Helpers;

namespace Simoja.Controllers;

[Authorize]
public class JenisKegiatanController : Controller {
    private IJenisKegiatan repo;

    public JenisKegiatanController(IJenisKegiatan jRepo) {
        repo = jRepo;
    }

    [HttpGet("/master/kawasan/jenis")]
    public IActionResult Index() => View("~/Views/Master/JenisKegiatan/Index.cshtml");

    [HttpGet("/master/kawasan/jenis/create")]
    public IActionResult Create() => PartialView("~/Views/Master/JenisKegiatan/AddEdit.cshtml", new JenisKegiatan());

    [HttpGet("/master/kawasan/jenis/edit")]
    public async Task<IActionResult> Edit(int jenisID) => PartialView("~/Views/Master/JenisKegiatan/AddEdit.cshtml",
        await repo.JenisKegiatans.FirstOrDefaultAsync(j => j.JenisKegiatanID == jenisID)
    );

    [HttpPost("/master/kawasan/jenis/save")]
    public async Task<IActionResult> SaveDataAsync(JenisKegiatan jenis) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(jenis);
            return Json(Result.Success());
        }
        
        return PartialView("~/Views/Master/JenisKegiatan/AddEdit.cshtml", jenis);
    }
}