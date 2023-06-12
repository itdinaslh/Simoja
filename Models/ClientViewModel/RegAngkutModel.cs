
using SharedLibrary.Entities.Transportation;

namespace Simoja.Models;

public class RegAngkutModel {
    #nullable disable
    public IzinAngkut IzinAngkut { get; set; }

    public string TglAwal { get; set; }

    public string TglAkhir { get; set; }

    public IFormFile FileIzin { get; set; }
}