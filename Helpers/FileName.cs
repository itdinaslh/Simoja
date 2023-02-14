using System.Text;

namespace Simoja.Helpers;

public static class FileName
{
    public static string GenerateRandomString()
    {
        int length = 40;

        StringBuilder builder = new();

        Random random = new();

        char letter;

        for (int i = 0; i < length; i++)
        {
            double flt = random.NextDouble();
            int shift = Convert.ToInt32(Math.Floor(25 * flt));
            letter = Convert.ToChar(shift + 65);
            builder.Append(letter);
        }

        return builder.ToString();
    }
}
