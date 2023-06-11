using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simoja.Entity;
using Simoja.Helpers;
using Simoja.Models;
using Simoja.Repository;

namespace Simoja.Controllers.Clients.JasaAngkut;

public class ReportAngkutController : Controller
{
    private readonly IClient clientRepo;
    private readonly IReportAngkut reportRepo;
    private readonly IKendaraan kendaraanRepo;
    private readonly ILokasiAngkut lokasiAngkutRepo;
    private readonly ILokasiBuang lokasiBuangRepo;

    public ReportAngkutController(IClient client, IReportAngkut reportRepo, IKendaraan kendaraanRepo, ILokasiAngkut lokasiAngkutRepo, ILokasiBuang lokasiBuangRepo)
    {
        this.clientRepo = client;
        this.reportRepo = reportRepo;
        this.kendaraanRepo = kendaraanRepo;
        this.lokasiAngkutRepo = lokasiAngkutRepo;
        this.lokasiBuangRepo = lokasiBuangRepo;
    }

    [HttpGet("/clients/pengangkutan/report")]
    public IActionResult Index()
    {
        return View("~/Views/Client/JasaAngkut/Report/Index.cshtml");
    }

    [HttpGet("/clients/pengangkutan/report/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Client/JasaAngkut/Report/Create.cshtml");
    }

    [HttpPost("/clients/pengangkutan/report/spj/store")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "PkmAngkut")]
    public async Task<IActionResult> StoreSPJ(SpjVM model)
    {
        var client = await clientRepo.Clients
            .Where(c => c.UserId == User.Identity!.Name)
            .Select(c => new {
                c.ClientID
            })
            .FirstOrDefaultAsync();

        var kendaraan = await kendaraanRepo.Kendaraans
            .Where(v => v.KendaraanID == model.SpjAngkut.KendaraanID)
            .FirstOrDefaultAsync();

        if (!model.EditMode)
        {
            model.SpjAngkut.SpjAngkutID = Guid.NewGuid();
            model.SpjAngkut.ClientID = client!.ClientID;
            model.SpjAngkut.NoSPJ = "0000-test-000";
            model.SpjAngkut.NoPolisi = kendaraan!.NoPolisi;
            model.SpjAngkut.NoPintu = kendaraan!.NoPintu;
            model.SpjAngkut.TglSPJ = DateOnly.ParseExact(model.TglSpj, "dd/MM/yyyy");
            model.SpjAngkut.DetaillSpjs = new List<DetaillSpj>();

            foreach (var data in model.DetailSpjVMs)
            {
                var loc = await lokasiAngkutRepo.LokasiAngkuts
                    .Where(x => x.LokasiAngkutID == data.LokasiAngkutID)
                    .Select(x => new
                    {
                        x.NamaLokasi,
                        x.Kawasan.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten,
                        x.Kawasan.Kelurahan.Kecamatan.NamaKecamatan,
                        x.Kawasan.Kelurahan.NamaKelurahan,
                        x.Kawasan.Alamat

                    }).FirstOrDefaultAsync();

                var buang = await lokasiBuangRepo.LokasiBuangs
                    .Where(x => x.LokasiBuangID == data.LokasiBuangID)
                    .Select(x => new
                    {
                        x.NamaLokasi
                    }).FirstOrDefaultAsync();

                var detail = new DetaillSpj
                {
                    DetailSpjID = Guid.NewGuid(),
                    SpjAngkutID = model.SpjAngkut.SpjAngkutID,
                    LokasiAngkutID = data.LokasiAngkutID,
                    NamaLokasi = loc!.NamaLokasi,
                    KotaAngkut = loc!.NamaKabupaten,
                    KecamatanAngkut = loc!.NamaKecamatan,
                    KelurahanAngkut = loc!.NamaKelurahan,
                    AlamatAngkut = loc!.Alamat,
                    LokasiBuangID = data.LokasiBuangID,
                    NamaLokasiBuang = buang!.NamaLokasi,
                    BeratSampah = data.Berat,
                    TglAngkut = DateOnly.ParseExact(data.TglAngkut, "dd/MM/yyyy")
                };

                model.SpjAngkut.DetaillSpjs.Add(detail);
                
            }

            if (ModelState.IsValid)
            {
                await reportRepo.SaveDataAsync(model);

                return Json(Result.Success());
            }

            return PartialView("~/Views/Client/JasaAngkut/Report/Create.cshtml", model);
        }

        return PartialView("~/Views/Client/JasaAngkut/Report/Create.cshtml", model);
    }
}
