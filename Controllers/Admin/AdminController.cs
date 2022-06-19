using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Helpers;
using Simoja.Entity;
using System.Net;

namespace Simoja.Controllers;

[Authorize(Roles = "SimojaAdmin, SystemAdmin")]
public class AdminController : Controller {
    private IClient clientRepo;

    public AdminController(IClient cRepo) {
        clientRepo = cRepo;
    }

    [HttpGet("/admin/data/jasa/verifikasi")]
    public IActionResult JasaUnverified() {
        return View();
    }
}