using Simoja.Entity;

namespace Simoja.Repository;

public interface IJenisKegiatan {
    IQueryable<JenisKegiatan> JenisKegiatans { get; }

    Task SaveDataAsync(JenisKegiatan jenis);
}