using Simoja.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("IzinOlah")]
public class IzinOlah {
    [Key]
    public Guid IzinOlahID { get; set; }

    public Guid ClientID { get; set; }

    #nullable disable
    [MaxLength(100)]
    [Required(ErrorMessage = "No Izin Usaha Wajib Diisi!")]
    public string NoIzinUsaha { get; set; }

    [Required(ErrorMessage = "Tanggal Terbit Izin Wajib Diisi~")]
    public DateOnly TglTerbitIzin { get; set; }

    [Required(ErrorMessage = "Tanggal Berakhir Izin Wajib Diisi")]
    public DateOnly TglAkhirIzin { get; set; }

    #nullable enable
    public string? DokumenIzin { get; set; }

    [Required(ErrorMessage = "Harap pilih lokasi terbit izin")]
    public int LokasiIzinID { get; set; }

    [Required(ErrorMessage = "Harap isi jumlah teknologi yang berizin")]
    public int JumlahTeknologi { get; set; }

#nullable enable

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    #nullable disable
    public Client Client { get; set; }

    public LokasiIzin LokasiIzin { get; set; }
}   