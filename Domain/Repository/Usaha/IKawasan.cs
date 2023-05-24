using Simoja.Entity;

namespace Simoja.Repository;

public interface IKawasan
{
    IQueryable<Kawasan> Kawasans { get; }

    Task SsveDataAsync(Kawasan kawasan);
}
