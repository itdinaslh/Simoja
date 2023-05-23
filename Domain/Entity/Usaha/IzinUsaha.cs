using System.ComponentModel.DataAnnotations;

namespace Simoja.Entity;

public class IzinUsaha
{
    [Key]
    public Guid IzinUsahaID { get; set; }

    public Guid ClientID { get; set; }

    [Required(ErrorMessage = "")]
    public int JenisKegiatanID { get; set; }
}
