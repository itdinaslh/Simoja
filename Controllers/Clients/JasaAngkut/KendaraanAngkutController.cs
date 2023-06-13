using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Helpers;
using Microsoft.AspNetCore.SignalR;
using SharedLibrary.Repositories.Transportation;
using SharedLibrary.Repositories.Common;
using SharedLibrary.Entities.Transportation;
using SharedLibrary.Entities.Common;
using Simoja.Hubs;

namespace Simoja.Controllers;

[Authorize(Roles = "PkmAngkut")]
public class KendaraanAngkutController : Controller
{
    private readonly IKendaraan vehicle;
    private readonly IClient clientRepo;
    private readonly INotification notificationRepo;
    private readonly IHubContext<NotificationHub> hubContext;

    public KendaraanAngkutController(IKendaraan vehicle, IClient clientRepo, INotification notificationRepo, IHubContext<NotificationHub> hubContext)
    {
        this.vehicle = vehicle;
        this.clientRepo = clientRepo;
        this.notificationRepo = notificationRepo;
        this.hubContext = hubContext;
    }

    [HttpGet("/clients/pengangkutan/kendaraan")]
    public async Task<IActionResult> Kendaraan(Guid id)
    {
        string? currentUser = User.Identity!.Name;

        await hubContext.Clients.All.SendAsync("ChangeNotif");

        var thisClient = await clientRepo.Clients.Where(c => c.ClientPkm!.UserEmail == currentUser)
            .Select(c => new {
                c.ClientID
            })
            .FirstOrDefaultAsync();

        var detail = await clientRepo.IzinAngkuts
            .Where(d => d.ClientID == thisClient!.ClientID)
            .SumAsync(i => i.JmlAngkutan);

        int jumlah = await vehicle.Kendaraans
            .Where(k => k.ClientID == thisClient!.ClientID)
            .CountAsync();

        bool isForbid = false;

        return View("~/Views/Client/JasaAngkut/Kendaraan.cshtml", new KendaraanIndexVM
        {
            IzinID = id,
            KendaranBerizin = detail,
            KendaraanDiinput = jumlah,
            Forbid = isForbid
        });
    }

    [HttpGet("/clients/pengangkutan/kendaraan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Client/JasaAngkut/KendaraanCreate.cshtml", new KendaraanCreateVM
        {
            Kendaraan = new Kendaraan
            {
                DokumenKendaraan = new DokumenKendaraan
                {
                    DokumenKendaraanID = Guid.NewGuid()
                }
            }            
        });
    }

    [HttpPost("/clients/pengangkutan/kendaraan/store")]    
    public async Task<IActionResult> StoreKendaraan(KendaraanCreateVM model)
    {
        var client = await clientRepo.Clients
            .Where(c => c.ClientPkm!.UserEmail == User.Identity!.Name)
            .Select(c => new {
                c.ClientID
            })
            .FirstOrDefaultAsync();

        //var kendaraan = await vehicle.Kendaraans
        //    .Where(v => v.KendaraanID == model.Kendaraan.KendaraanID)
        //    .FirstOrDefaultAsync();

        Guid uid = Guid.NewGuid();
        
        model.Kendaraan.ClientID = client!.ClientID;
        model.Kendaraan.StatusID = 3;
        model.Kendaraan.DokumenKendaraan!.TglSTNK = DateOnly.ParseExact(model.TglBerlakuSTNK, "dd/MM/yyyy");
        model.Kendaraan.DokumenKendaraan!.TglKIR = DateOnly.ParseExact(model.TglBerlakuKIR, "dd/MM/yyyy");        
        model.Kendaraan.DokumenKendaraan!.DokumenSTNK = await Upload.STNK(model.FileSTNK, client!.ClientID.ToString(), uid.ToString());
        model.Kendaraan.DokumenKendaraan!.DokumenKIR = await Upload.KIR(model.FileKIR, client!.ClientID.ToString(), uid.ToString());
        model.Kendaraan.DokumenKendaraan!.BuktiUjiEmisi = await Upload.UjiEmisi(model.FileUjiEmisi, client!.ClientID.ToString(), uid.ToString());
        model.Kendaraan.DokumenKendaraan!.FotoKendaraan = await Upload.FotoKendaraan(model.FotoKendaraan, client!.ClientID.ToString(), uid.ToString());

        if (ModelState.IsValid)
        {
            await vehicle.SaveKendaraanAsync(model.Kendaraan);
            var notif = new Notification
            {
                NotificationID = Guid.NewGuid(),
                NotificationTypeID = 1,
                UserID = "Admin",
                IsAdminNotification = true,
                Title = model.Kendaraan.NoPolisi,
                SubTitle = "Registrasi Baru",
                Content = "Menunggu Verifikasi dan no RFID",
                Href = "/admin/kendaraan/" + model.Kendaraan.KendaraanID
            };

            await notificationRepo.AddNotification(notif);
            await hubContext.Clients.All.SendAsync("ChangeNotif");

            return Json(Result.Success());
        }

        return PartialView("~/Views/Client/JasaAngkut/KendaraanCreate.cshtml", model);
    }
     
}
