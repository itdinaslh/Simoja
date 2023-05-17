using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class JenisIzinLingkunganService : IJenisIzinLingkungan
{
    private readonly AppDbContext context;

    public JenisIzinLingkunganService(AppDbContext context) => this.context = context;

    public IQueryable<JenisIzinLingkungan> JenisIzinLingkungans => context.JenisIzinLingkungans;

    public async Task SaveDataAsync(JenisIzinLingkungan jenis)
    {
        if (jenis.JenisIzinLingkunganID == 0)
        {
            await context.JenisIzinLingkungans.AddAsync(jenis);
        } else
        {
            JenisIzinLingkungan? data = await context.JenisIzinLingkungans.FindAsync(jenis.JenisIzinLingkunganID);

            if (data is not null)
            {
                data.NamaJenisIzin = jenis.NamaJenisIzin;
                data.UpdatedAt = DateTime.Now;

                context.JenisIzinLingkungans.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}
