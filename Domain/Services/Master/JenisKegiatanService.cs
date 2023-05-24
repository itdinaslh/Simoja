using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class JenisKegiatanService : IJenisKegiatan {
    private readonly AppDbContext context;

    public JenisKegiatanService(AppDbContext ctx) => context = ctx;

    public IQueryable<JenisKegiatan> JenisKegiatans => context.JenisKegiatans;

    #nullable disable
    public async Task SaveDataAsync(JenisKegiatan jenis) {
        if (jenis.JenisKegiatanID == 0) {
            await context.AddAsync(jenis);
        } else {
            JenisKegiatan jns = await context.JenisKegiatans.FirstOrDefaultAsync(j => j.JenisKegiatanID == jenis.JenisKegiatanID);
            jns.NamaKegiatan = jenis.NamaKegiatan.Trim();

            context.Update(jns);
        }

        await context.SaveChangesAsync();
    }
}