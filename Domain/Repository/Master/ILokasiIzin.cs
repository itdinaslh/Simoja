using Simoja.Domain.Entity;

namespace Simoja.Domain.Repository;

public interface ILokasiIzin
{
    IQueryable<LokasiIzin> LokasiIzins { get; }
}
