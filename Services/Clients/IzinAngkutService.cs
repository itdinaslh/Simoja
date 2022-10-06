using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class IzinAngkutService : IIzinAngkut {
    private AppDbContext context;

    public IzinAngkutService(AppDbContext ctx) => context = ctx;

    public IQueryable<IzinAngkut> IzinAngkuts => context.IzinAngkuts;
}