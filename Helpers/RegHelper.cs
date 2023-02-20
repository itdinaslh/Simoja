namespace Simoja.Helpers;

public static class RegHelper
{
    public static string NoRegistrasi(long NoUrut, string Jenis, DateTime TglDaftar)
    {
        string nomor = "PKM/" + GenerateSequence(NoUrut) + "/" + Jenis + "/" + TglDaftar.ToString("ddMMyy");

        return nomor;
    }

    private static string GenerateSequence(long urut)
    {
        string nomor = urut.ToString();

        while (nomor.Length < 6)
        {
            nomor = "0" + nomor;
        }

        return nomor;
    }
}
