using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simoja.Repository;

namespace Simoja.Controllers;

[Authorize]
public class AdminAngkutController : Controller
{
    private readonly IClient repo;

    public AdminAngkutController(IClient repo)
    {
        this.repo = repo;
    }
    
}
