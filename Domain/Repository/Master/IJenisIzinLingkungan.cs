using Simoja.Entity;

namespace Simoja.Repository;

public interface IJenisIzinLingkungan
{
    IQueryable<JenisIzinLingkungan> JenisIzinLingkungans { get; }

    Task SaveDataAsync(JenisIzinLingkungan jenis);
}
