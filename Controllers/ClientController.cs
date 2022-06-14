using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simoja.Models;
using Simoja.Repository;
using Simoja.Entity;

namespace Simoja.Controllers;

public class ClientController : Controller {
    private IClient repo;

    public ClientController(IClient cRepo) => repo = cRepo;

    public IActionResult Register() {
        return View(new Client());
    }

    [HttpPost]
    public IActionResult Register(Client client) {
        if(ModelState.IsValid) {

        }

        return View(client);
    }
}