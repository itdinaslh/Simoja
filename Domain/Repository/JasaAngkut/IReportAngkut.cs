using Simoja.Entity;
using Simoja.Models;

namespace Simoja.Repository;

public interface IReportAngkut
{
    IQueryable<SpjAngkut> SpjAngkuts { get; }

    Task SaveDataAsync(SpjVM data);
}
