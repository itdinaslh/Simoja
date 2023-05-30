using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class IzinKegiatanService : IIzinKegiatan
{
    private readonly AppDbContext context;

    public IzinKegiatanService(AppDbContext context) => this.context = context;

    public IQueryable<IzinKegiatan> IzinKegiatans => context.IzinKegiatans;

    public async Task SaveDataAsync(IzinKegiatan kawasan)
    {
        if (kawasan.IzinKegiatanID == Guid.Empty)
        {
            context.IzinKegiatans.Add(kawasan);
        }

        await context.SaveChangesAsync();
    }
}
