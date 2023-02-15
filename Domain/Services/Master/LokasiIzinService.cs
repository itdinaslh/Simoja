using Simoja.Data;
using Simoja.Domain.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class LokasiIzinService : ILokasiIzin
{
    private readonly AppDbContext context;

    public LokasiIzinService(AppDbContext context) { this.context = context; }

    public IQueryable<LokasiIzin> LokasiIzins => context.LokasiIzins;
}
