using Simoja.Entity;

namespace Simoja.Models;

public class DetailAngkutanVM
{
    public Client? Client { get; set; }    

    public string? NamaKabupaten { get; set; }

    public string? NamaKecamatan { get; set; }

    public string? NamaKelurahan { get; set; }

    public string? NamaJenisUsaha { get; set; }
}
