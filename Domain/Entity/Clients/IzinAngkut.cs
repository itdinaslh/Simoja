using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("IzinAngkut")]
public class IzinAngkut {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IzinAngkutID { get; set; }

    public Guid ClientID { get; set; }

    [Required(ErrorMessage = "Jumlah Angkutan Wajib Diisi!")]
    public int JmlAngkutan { get; set; }

    #nullable disable
    [MaxLength(100)]
    [Required(ErrorMessage = "No Izin Usaha Wajib Diisi!")]
    public string NoIzinUsaha { get; set; }

    [Required(ErrorMessage = "Tanggal Terbit Izin Wajib Diisi~")]
    public DateOnly TglTerbitIzin { get; set; }

    [Required(ErrorMessage = "Tanggal Berakhir Izin Wajib Diisi")]
    public DateOnly TglAkhirIzin { get; set; }
    
    #nullable enable
    public string? DokumenIzinPath { get; set; }

#nullable enable

    public Guid? UniqueID { get; set; } = Guid.NewGuid();

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    #nullable disable
    public Client Client { get; set; }
    
}   