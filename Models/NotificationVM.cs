using SharedLibrary.Entities.Common;

namespace Simoja.Models;

public class NotificationVM
{
    public int Count { get; set; }

    public List<Notification>? Notifications { get; set; }
}
