public static class IFileNameExtension {
    public static string TempFileName(this IFormFile file, bool randomName = true) {
        var ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));

        var filename = randomName ? Path.GetTempFileName() : file.FileName;

        var start = filename.LastIndexOf('\\');
        var end = filename.LastIndexOf('.');

        return filename.Substring(start, end - start) + ext;
    }
}