using Simoja.Entity;

namespace Simoja.Models;

public class KawasanCreateVM
{
#nullable disable
    public Kawasan Kawasan { get; set; }

#nullable enable

    public string? TglIzin { get; set; }

    public IFormFile? FileIzin { get; set; }
}
