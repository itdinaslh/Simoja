using Microsoft.EntityFrameworkCore;
using Simoja.Entity;

namespace Simoja.Data;

public class AppDbContext : DbContext {
    #nullable disable
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<JenisKegiatan> JenisKegiatans { get; set; }

    public DbSet<StatusKelola> StatusKelolas { get; set; }

    public DbSet<PihakAngkut> PihakAngkuts { get; set; }

    public DbSet<Provinsi> Provinsis { get; set; }

    public DbSet<Kabupaten> Kabupatens { get; set; }

    public DbSet<Kecamatan> Kecamatans { get; set; }

    public DbSet<Kelurahan> Kelurahans { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<DetailAngkut> DetailAngkuts { get; set; }

    public DbSet<DetailOlah> DetailOlahs { get; set; }

    public DbSet<DetailKawasan> DetailKawasans { get; set; }

    public DbSet<JenisKendaraan> JenisKendaraans { get; set; }

    public DbSet<Kendaraan> Kendaraans { get; set; }
}