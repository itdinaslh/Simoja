namespace Simoja.Models;

public class DetailSpjVM
{
    public Guid LokasiAngkutID { get; set; }

    public int LokasiBuangID { get; set; }

    public int Berat { get; set; }

#nullable disable

    public string TglAngkut { get; set; }
}
