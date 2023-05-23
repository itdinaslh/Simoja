using Simoja.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("UsahaDetail")]
public class UsahaDetail
{
    [Key]
    public Guid UsahaDetailID { get; set; } = Guid.NewGuid();

    public Guid ClientID { get; set; }

    public int JenisKegiatanID { get; set; }

#nullable disable

    public Client Client { get; set; }
}
