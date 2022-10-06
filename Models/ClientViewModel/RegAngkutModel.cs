using Simoja.Entity;

namespace Simoja.Models;

public class RegAngkutModel {
    #nullable disable
    public IzinAngkut DetailAngkut { get; set; }

    public string TglAwal { get; set; }

    public string TglAkhir { get; set; }
}