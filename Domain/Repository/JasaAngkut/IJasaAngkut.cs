using Simoja.Entity;

public interface IJasaAngkut {
    IQueryable<Kendaraan> Kendaraans { get; }
}