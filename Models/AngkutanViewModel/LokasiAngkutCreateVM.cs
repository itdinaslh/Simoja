using Simoja.Entity;
using System.ComponentModel.DataAnnotations;

namespace Simoja.Models;

public class LokasiAngkutCreateVM {

    public LokasiAngkut? LokasiAngkut { get; set; }

    [Required(ErrorMessage = "Harap pilih gedung/kawasan")]
    public string? NamaKota { get; set; }

    [Required(ErrorMessage = "Harap pilih gedung/kawasan")]
    public string? NamaKecamatan { get; set; }

    [Required(ErrorMessage = "Harap pilih gedung/kawasan")]
    public string? NamaKelurahan { get; set; }

    [Required(ErrorMessage = "Harap pilih gedung/kawasan")]
    public string? Alamat { get; set; }

    [Required(ErrorMessage = "Tanggal Awal Kontrak Wajib Diisi!")]
    public string TglAwal { get; set; } = String.Empty;

    [Required(ErrorMessage = "Tanggal Berakhir Kontrak Wajib Diisi!")]
    public string TglAkhir { get; set; } = String.Empty;

    [Required(ErrorMessage = "Harap upload dokumen kontrak kerjasama")]
    public IFormFile? FileDokumen { get; set; }
}