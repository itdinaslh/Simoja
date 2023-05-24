using Microsoft.EntityFrameworkCore;
using Simoja.Domain.Entity;
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
    public DbSet<IzinAngkut> IzinAngkuts { get; set; }
    public DbSet<IzinOlah> IzinOlahs { get; set; }
    public DbSet<Kawasan> Kawasans { get; set; }
    public DbSet<JenisKendaraan> JenisKendaraans { get; set; }
    public DbSet<Kendaraan> Kendaraans { get; set; }
    public DbSet<LokasiAngkut> LokasiAngkuts { get; set; }
    public DbSet<Flag> Statuses { get; set; }
    public DbSet<LokasiIzin> LokasiIzins { get; set; }
    public DbSet<LokasiBuang> LokasiBuangs { get; set; }
    public DbSet<JenisIzinLingkungan> JenisIzinLingkungans { get; set; }
}