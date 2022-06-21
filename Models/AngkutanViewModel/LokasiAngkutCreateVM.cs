using Simoja.Entity;

namespace Simoja.Models;

public class LokasiAngkutCreateVM {
    #nullable disable

    public LokasiAngkut LokasiAngkut { get; set; }

    public Guid UID { get; set; } = Guid.NewGuid();

    public string TglAwal { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");

    public string TglAkhir { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
}