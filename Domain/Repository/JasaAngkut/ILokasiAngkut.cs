using Simoja.Entity;

namespace Simoja.Repository;

public interface ILokasiAngkut {
    IQueryable<LokasiAngkut> LokasiAngkuts { get; }

    Task SaveLokasiAngkutAsync(LokasiAngkut lokasi);
}