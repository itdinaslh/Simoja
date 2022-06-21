using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class KendaraanService : IKendaraan {
    private AppDbContext context;

    public KendaraanService(AppDbContext ctx) => context = ctx;

    public IQueryable<JenisKendaraan> JenisKendaraans => context.JenisKendaraans;

    public IQueryable<Kendaraan> Kendaraans => context.Kendaraans;

    public async Task SaveJenisAsync(JenisKendaraan jenis) {
        if (jenis.JenisKendaraanId == 0) {
            await context.AddAsync(jenis);
        } else {
            var data = await context.JenisKendaraans.FindAsync(jenis.JenisKendaraanId);

            if (data is not null) {
                data.GlobalId = jenis.GlobalId;
                data.NamaJenis = jenis.NamaJenis;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }

    public async Task SaveKendaraanAsync(Kendaraan kendaraan) {
        if (kendaraan.KendaraanId == 0) {
            await context.AddAsync(kendaraan);
        } else {
            var data = await context.Kendaraans.FindAsync(kendaraan.KendaraanId);

            if (data is not null) {
                data.JenisKendaraanId = kendaraan.JenisKendaraanId;
                data.NoPolisi = kendaraan.NoPolisi;
                data.NoPintu = kendaraan.NoPintu;
                data.TglSTNK = kendaraan.TglSTNK;
                data.TglKIR = kendaraan.TglKIR;
                data.TahunPembuatan = kendaraan.TahunPembuatan;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}