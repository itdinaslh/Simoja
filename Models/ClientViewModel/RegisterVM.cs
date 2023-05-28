using Simoja.Entity;
using System.ComponentModel.DataAnnotations;

namespace Simoja.Models;

public class RegisterVM
{
#nullable disable

    public Client Client { get; set; }

    [Required(ErrorMessage = "Harap pilih provinsi")]
    public string ProvinsiID { get; set; }

    [Required(ErrorMessage = "Harap pilih kota/kabupaten")]
    public string KabupatenID { get; set; }

    [Required(ErrorMessage = "Harap pilih kecamatan")]
    public string KecamatanID { get; set; }

    [Required(ErrorMessage = "File KTP penanggung jawab wajib diupload")]
    public IFormFile FileKTP { get; set; }

    [Required(ErrorMessage = "File NPWP penanggung jawab wajib diupload")]
    public IFormFile FileNPWP { get; set; }

#nullable enable

    public IFormFile? FileNIB { get; set; }

    public bool EditMode { get; set; } = false;
}
