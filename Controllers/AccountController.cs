using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Simoja.Controllers;

public class AccountController : Controller {
    [Route("/account/denied")]
    public IActionResult Denied() {
        return View();
    }

    [HttpGet("/registrasi")]
    public IActionResult Register()
    {
        string uri = Simpanan.AuthServer + HttpUtility.UrlEncode(Simpanan.ReturnUrl);

        return Redirect(uri);
    }
}