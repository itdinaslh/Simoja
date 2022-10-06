using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Entity;

[Table("Flags")]
public class Flag
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FlagId { get; set; }

#nullable disable

    [Required(ErrorMessage = "Nama Status Wajib Diisi")]
    public string FlagName { get; set; }
}
