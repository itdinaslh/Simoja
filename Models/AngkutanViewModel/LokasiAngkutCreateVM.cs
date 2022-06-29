using Simoja.Entity;
using System.ComponentModel.DataAnnotations;

namespace Simoja.Models;

public class LokasiAngkutCreateVM {
    #nullable disable

    public LokasiAngkut LokasiAngkut { get; set; }

    public Guid UID { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Tanggal Awal Kontrak Wajib Diisi!")]
    public string TglAwal { get; set; } = String.Empty;

    [Required(ErrorMessage = "Tanggal Berakhir Kontrak Wajib Diisi!")]
    public string TglAkhir { get; set; } = String.Empty;
}