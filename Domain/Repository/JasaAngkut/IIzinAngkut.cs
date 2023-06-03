using Simoja.Entity;

public interface IIzinAngkut {
    IQueryable<IzinAngkut> IzinAngkuts { get; }

    Task AddKendaraan(Guid IzinAngkut, Kendaraan kendaraan);
}