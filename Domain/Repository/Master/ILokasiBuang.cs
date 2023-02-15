using Simoja.Domain.Entity;

namespace Simoja.Repository;

public interface ILokasiBuang
{
    IQueryable<LokasiBuang> LokasiBuangs { get; }
}
