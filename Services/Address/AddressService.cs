using Simoja.Entity;
using Simoja.Repository;
using Simoja.Data;


namespace Simoja.Services;

public class AddressService : IAddressRepo {
    private AppDbContext context;

    public AddressService(AppDbContext ctx) => context = ctx;

    public IQueryable<Kabupaten> Kabupatens => context.Kabupatens;

    public IQueryable<Kecamatan> Kecamatans => context.Kecamatans;

    public IQueryable<Kelurahan> Kelurahans => context.Kelurahans;
}