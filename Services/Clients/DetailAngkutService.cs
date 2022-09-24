using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class DetailAngkutService : IDetailAngkut {
    private AppDbContext context;

    public DetailAngkutService(AppDbContext ctx) => context = ctx;

    public IQueryable<DetailAngkut> DetailAngkuts => context.DetailAngkuts;
}