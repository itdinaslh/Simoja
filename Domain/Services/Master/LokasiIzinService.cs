using Simoja.Data;
using Simoja.Domain.Entity;
using Simoja.Domain.Repository;

namespace Simoja.Domain.Services;

public class LokasiIzinService : ILokasiIzin
{
    private readonly AppDbContext context;

    public LokasiIzinService(AppDbContext context) { this.context = context; }

    public IQueryable<LokasiIzin> LokasiIzins => context.LokasiIzins;
}
