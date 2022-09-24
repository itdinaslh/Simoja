using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Simoja.Helpers;

public static class Result {
    [Produces("application/json")]
    public static Dictionary<string, bool> Success() {
        var result = new Dictionary<string, bool>();
        result.Add("success", true);
        return result;
    }

    [Produces("application/json")]
    public static Dictionary<string, bool> Failed()
    {
        var result = new Dictionary<string, bool>();
        result.Add("failed", true);
        return result;
    }
}