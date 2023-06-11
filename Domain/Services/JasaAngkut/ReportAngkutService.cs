using Simoja.Data;
using Simoja.Entity;
using Simoja.Models;
using Simoja.Repository;

namespace Simoja.Services;

public class ReportAngkutService : IReportAngkut
{
    private readonly AppDbContext context;

    public ReportAngkutService(AppDbContext context) => this.context = context;

    public IQueryable<SpjAngkut> SpjAngkuts => context.SpjAngkuts;

    public async Task SaveDataAsync(SpjVM data)
    {
        if (!data.EditMode)
        {
            await context.SpjAngkuts.AddAsync(data.SpjAngkut);

            await context.DetaillSpjs.AddRangeAsync(data.SpjAngkut.DetaillSpjs);

            await context.SaveChangesAsync();
        }        
    }
}
