using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("Kawasan")]
public class Kawasan
{
    [Key]
    public Guid KawasanID { get; set; } = Guid.Empty;

    public Guid ClientID { get; set; }

#nullable disable

    [MaxLength(255)]
    public string NamaKawasan { get; set; }

    public int LokasiIzinID { get; set; }
    
    public int JenisKegiatanID { get; set; }

    public int JenisIzinLingkunganID { get; set; }

#nullable enable

    public DateOnly? TglTerbitIzin { get; set; }

    public string? DokumenIzin { get; set; }

    public bool? IsApproved { get; set; } = false;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    [MaxLength(100)]
    public string? NoIzinUsaha { get; set; }

#nullable disable

    public Client Client { get; set; }

    public LokasiIzin LokasiIzin { get; set; }

    public JenisKegiatan JenisKegiatan { get; set; }

    public JenisIzinLingkungan JenisIzinLingkungan { get; set; }
}
