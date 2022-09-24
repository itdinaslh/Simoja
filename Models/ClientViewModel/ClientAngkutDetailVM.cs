﻿using Simoja.Entity;

namespace Simoja.Models;

public class ClientAngkutDetailVM
{
    public Client? Client { get; set; }

    public string? NamaKelurahan { get; set; }

    public string? KecamatanId { get; set; }

    public string? NamaKecamatan { get; set; }

    public string? KabupatenId { get; set; }

    public string? NamaKabupaten { get; set; }

#nullable disable

    public string TglTerbitIzin { get; set; }

    public string TglAkhirIzin { get; set; }
}
