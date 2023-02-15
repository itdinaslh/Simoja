using Simoja.Domain.Entity;

namespace Simoja.Domain.Repository;

public interface ILokasiBuang
{
    IQueryable<LokasiBuang> LokasiBuangs { get; }
}
