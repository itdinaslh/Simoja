using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("Clients")]
public class Client {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClientId { get; set; }

    #nullable disable
    [Required(ErrorMessage = "Nama PT / Badan Usaha Wajib Diisi")]
    [MaxLength(100)]
    public string ClientName { get; set; }

    public bool IsVerified { get; set; } = false;

    [Required]
    public string UserId { get; set; }

    #nullable enable
    [MaxLength(15)]
    public string? Telp { get; set; }

    [MaxLength(15)]
    public string? Fax { get; set; }

    [MaxLength(15)]
    public string? KelurahanID { get; set; }

    [MaxLength(150)]
    public string? Alamat { get; set;}

    [MaxLength(50)]
    public string? Latitude { get; set; }

    [MaxLength(50)]
    public string? Longitude { get; set; }

    public int JenisUsahaId { get; set; }

    [MaxLength(75)]
    public string? PenanggungJawab { get; set; }

    [MaxLength(75)]
    public string? PIC { get; set; }

    [MaxLength(15)]
    public string? NoHpPIC { get; set; }

    [MaxLength(75)]
    public string? NoIzinUsaha { get; set; }
    
    public DateOnly? TglTerbitIzin { get; set; }

    public DateOnly? TglAkhirIzin { get; set; }

    public string? DokumenIzinPath { get; set; }

    [MaxLength(75)]
    public string? NIB { get; set; }

    public string? DokumenNIBPath { get; set ;}

    public DateTime? CreatedAt { get; set ;} = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    
    public Kelurahan? Kelurahan { get; set; }
}