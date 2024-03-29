using Simoja.Entity;

namespace Simoja.Repository;

public interface IIzinAngkut {
    IQueryable<IzinAngkut> IzinAngkuts { get; }

    Task AddKendaraan(Guid IzinAngkut, Kendaraan kendaraan);
}