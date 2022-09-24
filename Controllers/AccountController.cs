using Microsoft.AspNetCore.Mvc;

namespace Simoja.Controllers;

public class AccountController : Controller {
    [Route("/account/denied")]
    public IActionResult Denied() {
        return View();
    }
}