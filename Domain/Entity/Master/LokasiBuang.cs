﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simoja.Domain.Entity;

[Table("LokasiBuang")]
public class LokasiBuang
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LokasiBuangID { get; set; }

#nullable disable

    [MaxLength(50)]
    public string NamaLokasi { get; set; }
}
