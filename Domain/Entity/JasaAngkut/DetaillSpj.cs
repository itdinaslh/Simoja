using Simoja.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("DetailSpj")]
public class DetaillSpj
{
    [Key]
    public Guid DetailSpjID { get; set; }

    public Guid SpjAngkutID { get; set; }

    public Guid LokasiAngkutID { get; set; }

    [MaxLength(100)]
    public string? NamaLokasi { get; set; }

    [MaxLength(150)]
    public string? KotaAngkut { get; set; }

    [MaxLength(150)]
    public string? KecamatanAngkut { get; set; }

    [MaxLength(150)]
    public string? KelurahanAngkut { get; set; }

    [MaxLength(150)]
    public string? AlamatAngkut { get; set; }

    public int LokasiBuangID { get; set; }

    [MaxLength(50)]
    public string? NamaLokasiBuang { get; set; }

    public int BeratSampah { get; set; }

    public DateOnly TglAngkut { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

#nullable disable

    public SpjAngkut SpjAngkut { get; set; }

    public LokasiAngkut LokasiAngkut { get; set; }

    public LokasiBuang LokasiBuang { get; set; }


}
