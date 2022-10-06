using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("IzinKawasan")]
public class IzinlKawasan {
    #nullable disable
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IzinKawasanId { get; set; }
    
    public int ClientId { get; set; }

    [Required(ErrorMessage = "Pilih Jenis Kegiatan")]
    public int JenisKegiatanID { get; set; }

    [Required(ErrorMessage = "Pilih Status Pengelolaan")]
    public int StatusKelolaID { get; set; }

    #nullable enable
    public int? TimbulanAvg { get; set; }

    public bool? IsDipilah { get; set; } = false;

    public double? JumlahPilah { get; set; }

    [MaxLength(50)]
    public string? JenisPilah { get; set; }

    public bool? IsPembatasan { get; set; } = false;

    [MaxLength(50)]
    public string? Upaya { get; set; }

    public bool? PunyaTps { get; set; } = false;

    public bool? TpsTerpilah { get; set; } = false;

    [MaxLength(25)]
    public string? DimensiTps { get; set; }

    public bool? IsOlah { get; set; } = false;

    [MaxLength(50)]
    public string? JenisOlah { get; set; }

    [MaxLength(50)]
    public string? LokasiOlah { get; set; }

    public double? OlahAvg { get; set; }

    public int? PihakAngkutID { get; set; }

    [MaxLength(50)]
    public string? NamaPengolah { get; set; }

    [MaxLength(50)]
    public string? LokasiOlahLuar { get; set; }

    public string? WadahPath { get; set; }

    public string? TpsPath { get; set; }

    public string? PengolahanPath { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    #nullable disable
    public Client Client;

    public StatusKelola StatusKelola { get; set; }

    public JenisKegiatan JenisKegiatan { get; set; }

    #nullable enable
    public PihakAngkut? PihakAngkut { get; set; }
}