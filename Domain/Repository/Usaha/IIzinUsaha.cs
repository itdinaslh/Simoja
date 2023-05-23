using Simoja.Entity;

namespace Simoja.Repository;

public interface IIzinUsaha
{
    IQueryable<IzinUsaha> IzinUsahas { get; }
}
