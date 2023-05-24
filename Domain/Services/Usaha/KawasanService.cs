using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class KawasanService : IKawasan
{
    private readonly AppDbContext context;

    public KawasanService(AppDbContext context) => this.context = context;

    public IQueryable<Kawasan> Kawasans => context.Kawasans;

    public async Task SsveDataAsync(Kawasan kawasan)
    {
        if (kawasan.KawasanID == Guid.Empty)
        {
            context.Kawasans.Add(kawasan);
        }

        await context.SaveChangesAsync();
    }
}
