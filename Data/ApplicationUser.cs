using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Simoja.Data;

public class ApplicationUser : IdentityUser { 
    [MaxLength(50)]
    public string? FullName { get; set; }
}