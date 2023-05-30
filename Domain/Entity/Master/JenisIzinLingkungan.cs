using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

public class JenisIzinLingkungan
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JenisIzinLingkunganID { get; set; }

#nullable disable

    [Required(ErrorMessage = "Nama Jenis Izin Lingkungan Wajib Diisi")]
    [MaxLength(150)]
    public string NamaJenisIzin { get; set; }

#nullable enable
    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

#nullable disable

    public List<IzinKegiatan> Kawasans { get; set; }
}
