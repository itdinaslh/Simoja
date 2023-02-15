using Simoja.Data;
using Simoja.Domain.Entity;
using Simoja.Domain.Repository;

namespace Simoja.Domain.Services;

public class LokasiBuangService : ILokasiBuang
{
    private readonly AppDbContext context;

    public LokasiBuangService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<LokasiBuang> LokasiBuangs => context.LokasiBuangs;
}
