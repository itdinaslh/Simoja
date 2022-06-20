using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Simoja.Entity;

[Table("LokasiAngkut")]
[Index(nameof(UniqueId), IsUnique = true)]
public class LokasiAngkut {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LokasiAngkutId { get; set; }

    public int ClientId { get; set; }

    public Guid UniqueId { get; set; } = Guid.NewGuid();

    #nullable disable
    [Required(ErrorMessage = "Nama lokasi wajib diisi")]
    [MaxLength(100, ErrorMessage = "Maksimal 100 karakter")]
    public string NamaLokasi { get; set; }

    [MaxLength(15)]
    [Required(ErrorMessage = "Pilih Kelurahan")]
    public string KelurahanID { get; set; }

    [Required(ErrorMessage = "Alamat wajib diisi")]
    public string Alamat { get; set; }

    public DateOnly? TglAwalKontrak { get; set; }

    public DateOnly? TglAkhirKontrak { get; set; }

    public Client Client { get; set; }

    public Kelurahan Kelurahan { get; set; }
}