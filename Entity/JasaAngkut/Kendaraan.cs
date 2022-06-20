using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Simoja.Entity;

[Table("Kendaraan")]
public class Kendaraan {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int64 KendaraanId { get; set; }

    public int ClientId { get; set; }

    public Guid UniqueId { get; set; } = Guid.NewGuid();

    #nullable disable
    [Required(ErrorMessage = "No Polisi wajib diisi")]
    [MaxLength(25, ErrorMessage = "Max 25 Karakter")]
    public string NoPolisi { get; set; }

    [Required(ErrorMessage = "No Pintu wajib diisi")]
    [MaxLength(25, ErrorMessage = "Max 25 karakter")]
    public string NoPintu { get; set; }

    public int JenisKendaraanId { get; set; }

    [Required(ErrorMessage = "Tahun pembuatan wajib diisi")]
    [MaxLength(4, ErrorMessage = "Maksimal 4 karakter")]
    public string TahunPembuatan { get; set; }

    [Required(ErrorMessage = "Tanggal berlaku STNK wajib diisi")]
    public DateOnly TglSTNK { get; set; }

    [Required(ErrorMessage = "Dokumen STNK wajib diupload")]
    public string DokumenSTNK { get; set; }

    [Required(ErrorMessage = "Tanggal berlaku KIR wajib diisi")]
    public DateOnly TglKIR { get; set; }

    [Required(ErrorMessage = "Dokumen KIR wajib diupload")]
    public string DokumenKIR { get; set; }

    [Required(ErrorMessage = "Foto Kendaraan wajib diupload")]
    public string FotoKendaraan { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public Client Client { get; set; }

    public JenisKendaraan JenisKendaraan { get; set; }
}