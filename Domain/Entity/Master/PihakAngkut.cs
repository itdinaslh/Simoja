using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("PihakAngkut")]
public class PihakAngkut { 
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PihakAngkutID { get; set; }

    #nullable disable
    [Required(ErrorMessage = "Nama Pihak Pengangkut Wajib Diisi")]
    [MaxLength(50, ErrorMessage = "Max 50 Karakter")]
    public string NamaPihak { get; set; }

    public bool? IsActive { get; set; } = true;

    public List<IzinKegiatan> DetailKawasans { get; set; }
}