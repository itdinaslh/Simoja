using SharedLibrary.Repositories.Common;

namespace Simoja.Helpers;

public class Notification
{
    private readonly INotification repo;

    public Notification(INotification repo)
    {
        this.repo = repo;
    }

    public async Task AdminNewKendaraanVerification()
    {

    }
}
