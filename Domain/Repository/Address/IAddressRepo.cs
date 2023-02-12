using Simoja.Entity;

namespace Simoja.Repository;

public interface IAddressRepo {
    IQueryable<Provinsi> Provinsis { get; }

    IQueryable<Kabupaten> Kabupatens { get; }

    IQueryable<Kecamatan> Kecamatans { get; }

    IQueryable<Kelurahan> Kelurahans { get; }
}