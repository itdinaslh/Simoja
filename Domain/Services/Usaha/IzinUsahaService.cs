using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class IzinUsahaService : IIzinUsaha
{
    private readonly AppDbContext context;

    public IzinUsahaService(AppDbContext context) => this.context = context;

    public IQueryable<IzinUsaha> IzinUsahas => context.IzinUsahas;
}
