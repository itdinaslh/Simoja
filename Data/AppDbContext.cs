using Microsoft.EntityFrameworkCore;
using Simoja.Entity;

namespace Simoja.Data;

public class AppDbContext : DbContext {
    #nullable disable
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<JenisKegiatan> JenisKegiatans { get; set; }

    public DbSet<StatusKelola> StatusKelolas { get; set; }

    public DbSet<PihakAngkut> PihakAngkuts { get; set; }
}