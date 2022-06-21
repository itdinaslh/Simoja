using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class LokasiAngkutService : ILokasiAngkut {
    private AppDbContext context;

    public LokasiAngkutService(AppDbContext ctx) => context = ctx;

    public IQueryable<LokasiAngkut> LokasiAngkuts => context.LokasiAngkuts;

    public async Task SaveLokasiAngkutAsync(LokasiAngkut lokasi) {
        #nullable disable
        if (lokasi.LokasiAngkutId == 0) {
            await context.AddAsync(lokasi);
        } else {
            var data = await context.LokasiAngkuts.FindAsync(lokasi.LokasiAngkutId);

            data.NamaLokasi = lokasi.NamaLokasi;
            data.KelurahanID = lokasi.KelurahanID;
            data.Alamat = lokasi.Alamat;
            data.TglAwalKontrak = lokasi.TglAwalKontrak;
            data.TglAkhirKontrak = lokasi.TglAkhirKontrak;
            data.UpdatedAt = DateTime.Now;

            context.Update(data);
        }

        await context.SaveChangesAsync();
    }
}