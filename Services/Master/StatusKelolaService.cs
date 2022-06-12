using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class StatusKelolaService : IStatusKelola {
    private AppDbContext context;

    public StatusKelolaService(AppDbContext ctx) => context = ctx;

    public IQueryable<StatusKelola> StatusKelolas => context.StatusKelolas;

    #nullable disable
    public async Task SaveDataAsync(StatusKelola status) {
        if (status.StatusKelolaID == 0) {
            await context.AddAsync(status);
        } else {
            StatusKelola sts = await context.StatusKelolas.FirstOrDefaultAsync(s => s.StatusKelolaID == status.StatusKelolaID);
            sts.NamaStatus = status.NamaStatus.Trim();

            context.Update(sts);
        }

        await context.SaveChangesAsync();
    }
}