using Microsoft.AspNetCore.Mvc;

namespace Simoja.Controllers;

public class WebController : Controller {
    [HttpGet("/")]
    public IActionResult Index() => View();

    [HttpGet("/web/usaha-kegiatan")]
    public IActionResult Usaha() => View();

    [HttpGet("/web/penyedia-jasa")]
    public IActionResult PenyediaJasa() => View();


    [HttpGet("/web/jasa-pengangkutan-sampah")]
    public IActionResult JasaAngkut() => View();

    [HttpGet("/web/jasa-pengolahan-sampah")]
    public IActionResult JasaOlah() => View();


    [HttpGet("/web/kinerjaps")]
    public IActionResult Kinerjaps() => View();

    [HttpGet("/web/kontak")]
    public IActionResult Kontak() => View();
}