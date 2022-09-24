using Simoja.Entity;

namespace Simoja.Repository;

public interface IStatusKelola {
    IQueryable<StatusKelola> StatusKelolas { get; }

    Task SaveDataAsync(StatusKelola status);
}