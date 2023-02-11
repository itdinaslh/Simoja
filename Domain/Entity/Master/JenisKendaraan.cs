using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Simoja.Entity;

[Table("JenisKendaraan")]
[Index(nameof(GlobalId), IsUnique = true)]
public class JenisKendaraan {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JenisKendaraanID { get; set; }

    #nullable disable
    [Required(ErrorMessage = "Global Unique ID wajib diisi")]
    [MaxLength(20)]
    public string GlobalId { get; set; }

    [Required(ErrorMessage = "Jenis Kendaraan wajib diisi")]
    [MaxLength(50)]
    public string NamaJenis { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public List<Kendaraan> Kendaraans { get; set; }
}