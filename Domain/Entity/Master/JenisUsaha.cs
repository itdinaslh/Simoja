using Simoja.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

public class JenisUsaha
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JenisUsahaID { get; set; }

#nullable disable

    [MaxLength(10)]
    public string Prefix { get; set; }

    [MaxLength(50)]
    public string NamaJenis { get; set; }

    public List<Client> Clients { get; set; }
}
