using Simoja.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("IzinAngkut")]
public class IzinAngkut {
    [Key]
    public Guid IzinAngkutID { get; set; }

    public Guid ClientID { get; set; }

    public Guid UniqueID { get; set; }

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
    public string? DokumenIzin { get; set; }

    [Required(ErrorMessage = "Harap pilih lokasi terbit izin")]
    public int LokasiIzinID { get; set; }

#nullable enable

    public int? LokasiBuangID { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    #nullable disable
    public Client Client { get; set; }

    public LokasiIzin LokasiIzin { get; set; }

    public LokasiBuang LokasiBuang { get; set; }

    public ICollection<Kendaraan> Kendaraans { get; set; }
    
}   