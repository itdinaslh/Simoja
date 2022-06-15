using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Entity;

namespace Simoja.Controllers;

[Authorize]
public class ClientController : Controller {
    private IClient repo;

    public ClientController(IClient cRepo) => repo = cRepo;

    [HttpGet("/clients/register")]
    public IActionResult Register() {
        return View(new Client());
    }

    [HttpPost("/clients/register")]
    public IActionResult Register(Client client) {
        if(ModelState.IsValid) {

        }

        return View(client);
    }
}