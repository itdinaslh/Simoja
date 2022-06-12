using Microsoft.AspNetCore.Mvc;

namespace Simoja.Controllers;

public class WebController : Controller {
    [HttpGet("/")]
    public IActionResult Index() => View();

    
}