using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class LokasiAngkutService : ILokasiAngkut {
    private readonly AppDbContext context;

    public LokasiAngkutService(AppDbContext ctx) => context = ctx;

    public IQueryable<LokasiAngkut> LokasiAngkuts => context.LokasiAngkuts;

    public async Task SaveLokasiAngkutAsync(LokasiAngkut lokasi) {
        if (lokasi.LokasiAngkutID == Guid.Empty) {
            await context.AddAsync(lokasi);
        } else {
            var data = await context.LokasiAngkuts.FindAsync(lokasi.LokasiAngkutID);

            if (data != null)
            {
                data.NamaLokasi = lokasi.NamaLokasi;
                data.KawasanID = lokasi.KawasanID;
                data.TglAwalKontrak = lokasi.TglAwalKontrak;
                data.TglAkhirKontrak = lokasi.TglAkhirKontrak;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }
            
        }

        await context.SaveChangesAsync();
    }
}