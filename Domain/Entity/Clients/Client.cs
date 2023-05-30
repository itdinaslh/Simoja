using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("Clients")]
public class Client {
    [Key]    
    public Guid ClientID { get; set; } = Guid.Empty;    

    #nullable disable
    [Required(ErrorMessage = "Nama PT / Badan Usaha Wajib Diisi")]
    [MaxLength(100)]
    public string ClientName { get; set; }

    public bool IsVerified { get; set; } = false;
    
    public string UserId { get; set; }

    [MaxLength(15)]
    [Required(ErrorMessage = "No Telp Wajib Diisi")]
    public string Telp { get; set; }

    #nullable enable
   
    [MaxLength(15)]
    public string? Fax { get; set; }


    #nullable disable
    [MaxLength(15)]
    [Required(ErrorMessage = "Harap pilih kelurahan")]
    public string KelurahanID { get; set; }
    
    [MaxLength(150)]
    [Required(ErrorMessage = "Alamat wajib diisi")]
    public string Alamat { get; set;}

    #nullable enable
    [MaxLength(50)]
    public string? Latitude { get; set; }

    [MaxLength(50)]
    public string? Longitude { get; set; }

#nullable disable

    [MaxLength(75)]
    [Required(ErrorMessage = "Penanggung jawab wajib diisi")]
    public string PenanggungJawab { get; set; }

    [Required(ErrorMessage = "NIK / No KTP Penanggung Jawab wajib diisi")]
    [Display(Name = "NIK / No KTP")]
    [Range(0, 9999999999999999, ErrorMessage = "Masukan format NIK dengan benar")]
    [StringLength(16, MinimumLength = 16, ErrorMessage = "NIK harus 16 karakter")]
    [MaxLength(16)]
    public string NIK { get; set; }

    [Required(ErrorMessage = "No. NPWP Penanggung Jawab wajib diisi")]
    [MaxLength(30)]
    public string NPWP { get; set; }

    [MaxLength(75)]
    [Required(ErrorMessage = "Nama PIC wajib diisi")]
    public string PIC { get; set; }

    [MaxLength(15)]
    [Required(ErrorMessage = "No. HP PIC wajib diisi")]
    public string NoHpPIC { get; set; }

    [MaxLength(255)]
    public string DokumenKTP { get; set; }

    [MaxLength(255)]
    public string DokumenNPWP { get; set; }

    [MaxLength(150)]
    [Required(ErrorMessage = "No NIB wajib diisi")]
    public string NIB { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long NoUrut { get; set; }

#nullable enable

    [MaxLength(255)]
    public string? DokumenNIB { get; set; }

    public int? FlagID { get; set; }

    public DateTime? CreatedAt { get; set ;} = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    
    #nullable disable
    public Kelurahan Kelurahan { get; set; }

    public List<IzinAngkut> IzinAngkuts { get; set; }

    public List<IzinOlah> IzinOlahs { get; set; }

    public Flag Flag { get; set; }

    public List<LokasiAngkut> LokasiAngkuts { get; set; }

    public List<IzinKegiatan> IzinKawasans { get; set; }

    public List<JenisUsaha> JenisUsahas { get; set; }

}