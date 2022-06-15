using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("StatusKelola")]
public class StatusKelola {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StatusKelolaID { get; set; }

    #nullable disable
    [Required(ErrorMessage = "Nama Status Kelola Wajib Diisi")]
    [MaxLength(50, ErrorMessage = "Max 50 Karakter")]
    public string NamaStatus { get; set; }

    public bool? IsActive { get; set; } = true;

    public List<DetailKawasan> DetailKawasans { get; set; }
}