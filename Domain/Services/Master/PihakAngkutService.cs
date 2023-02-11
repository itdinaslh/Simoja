using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class PihakAngkutService : IPihakAngkut {
    private AppDbContext context;

    public PihakAngkutService(AppDbContext ctx) => context = ctx;

    public IQueryable<PihakAngkut> PihakAngkuts => context.PihakAngkuts;

    #nullable disable
    public async Task SaveDataAsync(PihakAngkut pihak) {
        if (pihak.PihakAngkutID == 0) {
            await context.AddAsync(pihak);
        } else {
            PihakAngkut phk = await context.PihakAngkuts.FirstOrDefaultAsync(p => p.PihakAngkutID == pihak.PihakAngkutID);
            phk.NamaPihak = pihak.NamaPihak.Trim();

            context.Update(phk);
        }

        await context.SaveChangesAsync();
    }
}