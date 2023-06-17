using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Entities.Transportation;
using SharedLibrary.Repositories.Transportation;
using Simoja.Models;
using Simoja.Helpers;

namespace Simoja.Controllers.Admin.JasaAngkut;

public class KendaraanAdminController : Controller
{
    private readonly IKendaraan vehicleRepo;

    public KendaraanAdminController(IKendaraan vehicleRepo) => this.vehicleRepo = vehicleRepo;

    [HttpGet("/admin/kendaraan")]
    public async Task<IActionResult> DetailKendaraan(Guid id)
    {
        Kendaraan? vehicle = await vehicleRepo.Kendaraans
            .Include(t => t.TipeKendaraan)
            .Include(d => d.DokumenKendaraan)
            .FirstOrDefaultAsync(x => x.KendaraanID == id);

        if (vehicle != null)
        {
            return View("~/Views/Admin/Angkutan/Kendaraan/Details.cshtml", new KendaraanDetailVM
            {
                Kendaraan = vehicle,
                MasaBerlakuSTNK = vehicle.DokumenKendaraan!.TglSTNK.ToString("dd/MM/yyyy"),
                MasaBerlakuKIR = vehicle.DokumenKendaraan!.TglKIR.ToString("dd/MM/yyyy"),
                TglUjiEmosi = vehicle.DokumenKendaraan!.TglUjiEmisi.ToString("dd/MM/yyyy")
            });
        }

        return NotFound();
    }

    [HttpPost("/admin/kendaraan/update")]
    public async Task<IActionResult> UpdateKendaraan(KendaraanDetailVM model)
    {

        model.Kendaraan.DokumenKendaraan!.TglSTNK = DateOnly.ParseExact(model.MasaBerlakuSTNK, "dd/MM/yyyy");
        model.Kendaraan.DokumenKendaraan!.TglKIR = DateOnly.ParseExact(model.MasaBerlakuKIR, "dd/MM/yyyy");
        model.Kendaraan.DokumenKendaraan!.TglUjiEmisi = DateOnly.ParseExact(model.TglUjiEmosi, "dd/MM/yyyy");
        model.Kendaraan.StatusID = 2;
        model.Kendaraan.IsVerified = true;

        if (ModelState.IsValid)
        {
            await vehicleRepo.SaveKendaraanAsync(model.Kendaraan);

            return Json(Result.Success());
        }

        return View("~/Views/Admin/Angkutan/Kendaraan/Details.cshtml", model);
    }
}
