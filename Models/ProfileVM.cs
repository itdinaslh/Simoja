using Simoja.Entity;
using System.ComponentModel.DataAnnotations;

namespace Simoja.Models;

public class ProfileVM
{
#nullable disable
    public Client Client { get; set; }   

    public string NamaKelurahan { get; set; }

    [Required(ErrorMessage = "Harap pilih kota/kabupaten")]
    public string KabupatenID { get; set; }

    public string NamaKabupaten { get; set; }

    [Required(ErrorMessage = "Harap pilih kecamatan")]
    public string KecamatanID { get; set; }
    
    public string NamaKecamatan { get; set; }
}
