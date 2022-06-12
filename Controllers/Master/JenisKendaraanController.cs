using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Repository;
using Simoja.Entity;
using Simoja.Helpers;

namespace Simoja.Controllers;

[Authorize]
public class JenisKendaraanController : Controller {
    [HttpGet("/master/jenis-kendaraan")]
    public IActionResult Index() {
        return View("~/Views/Master/JenisKendaraan/Index.cshtml");
    }
}