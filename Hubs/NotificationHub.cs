using Microsoft.AspNetCore.SignalR;

namespace Simoja.Hubs;

public class NotificationHub : Hub
{
    public async Task ChangeNotif()
    {
        await Clients.All.SendAsync("ChangeNotif");
    }
}
