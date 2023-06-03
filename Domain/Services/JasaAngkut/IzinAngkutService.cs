using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class IzinAngkutService : IIzinAngkut {
    private AppDbContext context;

    public IzinAngkutService(AppDbContext ctx) => context = ctx;

    public IQueryable<IzinAngkut> IzinAngkuts => context.IzinAngkuts;

    public async Task AddKendaraan(Guid Izin, Kendaraan kendaraan)
    {
        var data = await context.IzinAngkuts.FindAsync(Izin);

        if (data != null)
        {
            data.Kendaraans = new List<Kendaraan>
            {
                kendaraan
            };
        }

        await context.SaveChangesAsync();
    }
}