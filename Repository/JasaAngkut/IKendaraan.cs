using Simoja.Entity;

namespace Simoja.Repository;

public interface IKendaraan {
    IQueryable<JenisKendaraan> JenisKendaraans { get; }

    IQueryable<Kendaraan> Kendaraans { get; }

    Task SaveJenisAsync(JenisKendaraan jenis);

    Task SaveKendaraanAsync(Kendaraan kendaraan);
}