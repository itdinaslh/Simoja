using Simoja.Entity;

namespace Simoja.Models;

public class KendaraanIndexVM {
    public Guid IzinID { get; set; }

    public int KendaranBerizin { get; set; } = 0;

    public int KendaraanDiinput { get; set; } = 0;

    public bool Forbid { get; set; } = false;
}