using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Repositories.Common;
using Simoja.Models;

namespace Simoja.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotification repo;

    public NotificationController(INotification repo) => this.repo = repo;

    [HttpGet("/service/notifications")]
    public async Task<IActionResult> GetNotificationHeader()
    {
        bool isAdmin = User.IsInRole("SysAdmin") || User.IsInRole("PkmAdmin");

        if (isAdmin)
        {
            var data = await repo.Notifications.Where(x => x.IsAdminNotification == true).OrderByDescending(x => x.CreatedAt).ToListAsync();

            int count = data.Count;

            var VM = new NotificationVM
            {
                Count = count,
                Notifications = data
            };

            return Ok(VM);
        }
        else
        {
            var user = User.Identity!.Name;

            var data = await repo.Notifications.Where(x => x.UserID == user).ToListAsync();

            var clientVM = new NotificationVM
            {
                Count = data.Count,
                Notifications = data
            };

            return Ok(clientVM);
        }

    }
}
