using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("DetailAngkut")]
public class DetailAngkut {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DetailAngkutId { get; set; }

    public int ClientId { get; set; }

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

    [Required(ErrorMessage = "Wajib Upload Dokumen Izin!")]
    public string DokumenIzinPath { get; set; }

    [Required(ErrorMessage = "NIB Wajib Diisi!")]
    [MaxLength(100)]
    public string NIB { get; set; }

    [Required(ErrorMessage = "Wajib Upload NIB")]
    public string NIBPath { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public Client Client { get; set; }
    
}   