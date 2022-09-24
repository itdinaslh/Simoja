using Simoja.Entity;
using System.ComponentModel.DataAnnotations;

namespace Simoja.Models;

public class KendaraanCreateVM {
    #nullable disable    
    public Kendaraan Kendaraan { get; set; }

    [Required]
    public string TglBerlakuSTNK { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");

    public string TglBerlakuKIR { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");

    public Guid UID { get; set; } = Guid.NewGuid();

    public bool StnkAdded { get; set; } = false;

    public bool? KirAdded { get; set; } = false;

    public bool? FotoIsAdded { get; set; } = false;
}