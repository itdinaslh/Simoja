using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Helpers;
using Simoja.Entity;
using System.Net;

namespace Simoja.Controllers;

[Authorize(Roles = "SimojaAngkut")]
public class JasaAngkutController : Controller {
    [HttpGet("/dashboard/pengangkutan")]
    public IActionResult Dashboard() {
        return View();
    }
}