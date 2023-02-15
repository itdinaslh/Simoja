using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Domain.Entity;

[Table("LokasiIzin")]
public class LokasiIzin
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LokasiIzinID { get; set; }

#nullable disable
    [MaxLength(50)]
    public string NamaLokasi { get; set; }
}
