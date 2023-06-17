using SharedLibrary.Entities.Transportation;

namespace Simoja.Models;

public class KendaraanDetailVM
{
#nullable disable
    public Kendaraan Kendaraan { get; set; }

    public string MasaBerlakuSTNK { get; set; }

    public string MasaBerlakuKIR { get; set; }

    public string TglUjiEmosi { get; set; }

}
