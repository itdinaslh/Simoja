using Simoja.Entity;

public interface ILokasiAngkut {
    IQueryable<LokasiAngkut> LokasiAngkuts { get; }

    Task SaveLokasiAngkutAsync(LokasiAngkut lokasi);
}