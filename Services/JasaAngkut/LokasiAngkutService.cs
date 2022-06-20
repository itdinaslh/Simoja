using Microsoft.EntityFrameworkCore;
using Simoja.Data;
using Simoja.Entity;
using Simoja.Repository;

namespace Simoja.Services;

public class LokasiAngkutService : ILokasiAngkut {
    private AppDbContext context;

    public LokasiAngkutService(AppDbContext ctx) => context = ctx;

    public IQueryable<LokasiAngkut> LokasiAngkuts => context.LokasiAngkuts;
}