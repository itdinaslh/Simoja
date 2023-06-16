using SharedLibrary.Entities.Common;

namespace Simoja.Models;

public class ClientDetailVM
{
    public Client? Client { get; set; }

    public string? NamaKelurahan { get; set; }

    public string? KecamatanId { get; set; }

    public string? NamaKecamatan { get; set; }

    public string? KabupatenId { get; set; }

    public string? NamaKabupaten { get; set; }

}
