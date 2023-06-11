using Simoja.Entity;

namespace Simoja.Models;

public class SpjVM
{
#nullable disable
    public SpjAngkut SpjAngkut { get; set; }

    public string TglSpj { get; set; }

    public List<DetailSpjVM> DetailSpjVMs { get; set; }

    public bool EditMode { get; set; } = false;
}
