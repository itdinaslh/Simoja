using Simoja.Entity;

namespace Simoja.Repository;

public interface IIzinKegiatan
{
    IQueryable<IzinKegiatan> IzinKegiatans { get; }

    Task SaveDataAsync(IzinKegiatan izin);
}
