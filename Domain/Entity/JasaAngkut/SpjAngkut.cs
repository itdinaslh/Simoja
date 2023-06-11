using Simoja.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("SpjAngkut")]
public class SpjAngkut
{
    [Key]
    public Guid SpjAngkutID { get; set; } = Guid.Empty;

    public Guid ClientID { get; set; }

    public long KendaraanID { get; set; }

#nullable disable

    [MaxLength(50)]
    public string NoSPJ { get; set; }

    [MaxLength(25)]
    public string NoPolisi { get; set; }

    [MaxLength(25)]
    public string NoPintu { get; set; }

    public bool IsFinished { get; set; } = false;

    public bool IsEmergency { get; set; } = false;


#nullable enable

    [MaxLength(25)]
    public string? NoStruk { get; set; }

    public int? TonaseTimbangan { get; set; }

    [Required(ErrorMessage = "Harap isi tanggal SPJ")]
    public DateOnly TglSPJ { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

#nullable disable

    public Client Client { get; set; }

    public Kendaraan Kendaraan { get; set; }

    public List<DetaillSpj> DetaillSpjs { get; set; }
}
