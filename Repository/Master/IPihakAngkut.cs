using Simoja.Entity;

namespace Simoja.Repository;

public interface IPihakAngkut {
    IQueryable<PihakAngkut> PihakAngkuts { get; }

    Task SaveDataAsync(PihakAngkut pihak);
}