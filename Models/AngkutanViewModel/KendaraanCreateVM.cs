using Simoja.Entity;
using System.ComponentModel.DataAnnotations;

namespace Simoja.Models;

public class KendaraanCreateVM {
    #nullable disable    
    public Kendaraan Kendaraan { get; set; }

    public Guid IzinID { get; set; }

    [Required]
    public string TglBerlakuSTNK { get; set; }

    public string TglBerlakuKIR { get; set; }

    public Guid UID { get; set; } = Guid.NewGuid();

    public List<IFormFile> FileSTNK { get; set; }

    public List<IFormFile> FileKIR { get; set; }

    public List<IFormFile> FileUjiEmisi { get; set; }

    public List<IFormFile> FotoKendaraan { get; set; }

    //public bool StnkAdded { get; set; } = false;

    //public bool? KirAdded { get; set; } = false;

    //public bool? FotoIsAdded { get; set; } = false;
}