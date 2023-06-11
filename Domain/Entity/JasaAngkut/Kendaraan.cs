using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Simoja.Entity;

[Table("Kendaraan")]
[Index(nameof(UniqueID), IsUnique = true)]
public class Kendaraan {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long KendaraanID { get; set; }

    public Guid ClientID { get; set; }

    public Guid UniqueID { get; set; } = Guid.NewGuid();

    #nullable disable
    [Required(ErrorMessage = "No Polisi wajib diisi")]
    [MaxLength(25, ErrorMessage = "Max 25 Karakter")]
    public string NoPolisi { get; set; }

    [Required(ErrorMessage = "No Pintu wajib diisi")]
    [MaxLength(25, ErrorMessage = "Max 25 karakter")]
    public string NoPintu { get; set; }

    public int JenisKendaraanId { get; set; }

    [Required(ErrorMessage = "Tahun pembuatan wajib diisi")]
    [MaxLength(4, ErrorMessage = "Maksimal 4 karakter")]
    public string TahunPembuatan { get; set; }

    [Required(ErrorMessage = "Tanggal berlaku STNK wajib diisi")]
    public DateOnly TglSTNK { get; set; }

    [Required(ErrorMessage = "Tanggal berlaku KIR wajib diisi")]
    public DateOnly TglKIR { get; set; }

    #nullable enable
    public string? DokumenSTNK { get; set; }
    
    public string? DokumenKIR { get; set; }
    
    public string? FotoKendaraan { get; set; }

    public string? BuktiUjiEmisi { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    # nullable disable

    public JenisKendaraan JenisKendaraan { get; set; }

    public Client Client { get; set; }

    public List<IzinAngkut> IzinAngkuts { get; set; }

    public List<SpjAngkut> SpjAngkuts { get; set; }

}