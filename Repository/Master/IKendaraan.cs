using Simoja.Entity;

public interface IKendaraan {
    IQueryable<JenisKendaraan> JenisKendaraans { get; }

    IQueryable<Kendaraan> Kendaraans { get; }

    Task SaveDataAsync(JenisKendaraan jenis);
}