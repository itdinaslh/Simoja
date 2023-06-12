namespace Simoja.Helpers;

public static class Upload
{
    public static async Task<string> KTP(IFormFile file, string userid)
    {
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + userid);

        string ktpPath = path + "/ktp";
        string extKtp = Path.GetExtension(file.FileName);
        string fileNameKTP = FileName.GenerateRandomString().ToLower() + extKtp;

        if (!Directory.Exists(ktpPath))
        {
            Directory.CreateDirectory(ktpPath);
        }

        using (FileStream stream = new(Path.Combine(ktpPath, fileNameKTP), FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        if (!extKtp.Contains("pdf"))
        {
            Image image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(600, 400));

            image.Save(ktpPath + "/" + "thumbnail-" + fileNameKTP);
        }

        return fileNameKTP;
    }

    public static async Task<string> NPWP(IFormFile file, string userid)
    {
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + userid);

        string npwpPath = path + "/npwp";
        string extNpwp = Path.GetExtension(file.FileName);
        string fileNameNpwp = FileName.GenerateRandomString().ToLower() + extNpwp;

        if (!Directory.Exists(npwpPath))
        {
            Directory.CreateDirectory(npwpPath);
        }

        using (FileStream stream = new(Path.Combine(npwpPath, fileNameNpwp), FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        if (!extNpwp.Contains("pdf"))
        {
            Image image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(600, 400));

            image.Save(npwpPath + "/" + "thumbnail-" + fileNameNpwp);
        }

        return fileNameNpwp;
    }

    public static async Task<string> NIB(IFormFile file, string userid)
    {
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + userid);

        string nibPath = path + "/nib";
        string extNib = Path.GetExtension(file.FileName);
        string fileNameNib = FileName.GenerateRandomString().ToLower() + extNib;

        if (!Directory.Exists(nibPath))
        {
            Directory.CreateDirectory(nibPath);
        }

        using (FileStream stream = new(Path.Combine(nibPath, fileNameNib), FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        if (!extNib.Contains("pdf"))
        {
            Image image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(600, 400));

            image.Save(nibPath + "/" + "thumbnail-" + fileNameNib);
        }

        return fileNameNib;
    }

    public static async Task<string> IzinAngkut(IFormFile file, string userid)
    {
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + userid);

        string izinPath = path + "/izin-angkut";
        string extIzin = Path.GetExtension(file.FileName);
        string fileNameIzin = FileName.GenerateRandomString().ToLower() + extIzin;

        if (!Directory.Exists(izinPath))
        {
            Directory.CreateDirectory(izinPath);
        }

        using (FileStream stream = new(Path.Combine(izinPath, fileNameIzin), FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        if (!extIzin.Contains("pdf"))
        {
            Image image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(600, 400));

            image.Save(izinPath + "/" + "thumbnail-" + fileNameIzin);
        }

        return fileNameIzin;
    }

    public static async Task<string> STNK(List<IFormFile> files, string clientid, string uid)
    {
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + clientid);

        string stnkPath = path + "/stnk/" + uid;

        string thumbPath = path + "/thumbnails/stnk/" + uid;

        string savePath = "/clients/" + clientid + "/stnk/" + uid;

        if (!Directory.Exists(stnkPath))
        {
            Directory.CreateDirectory(stnkPath);
        }

        if (!Directory.Exists(thumbPath))
        {
            Directory.CreateDirectory(thumbPath);
        }

        foreach (var file in files)
        {
            FileInfo fileInfo = new(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(stnkPath, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if (!fileName.Contains("pdf"))
            {
                Image image = Image.Load(file.OpenReadStream());
                image.Mutate(x => x.Resize(600, 400));

                image.Save(Path.Combine(thumbPath, fileName));
            }
        }

        return savePath;
    }

    public static async Task<string> KIR(List<IFormFile> files, string clientid, string uid)
    {
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + clientid);

        string kirPath = path + "/kir/" + uid;

        string thumbPath = path + "/thumbnails/kir/" + uid;

        string savePath = "/clients/" + clientid + "/kir/" + uid;

        if (!Directory.Exists(kirPath))
        {
            Directory.CreateDirectory(kirPath);
        }

        if (!Directory.Exists(thumbPath))
        {
            Directory.CreateDirectory(thumbPath);
        }

        foreach (var file in files)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(kirPath, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if (!fileName.Contains("pdf"))
            {
                Image image = Image.Load(file.OpenReadStream());
                image.Mutate(x => x.Resize(600, 400));

                image.Save(Path.Combine(thumbPath, fileName));
            }
        }

        return savePath;
    }

    public static async Task<string> UjiEmisi(List<IFormFile> files, string clientid, string uid)
    {
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + clientid);

        string ujiPath = path + "/emisi/" + uid;

        string thumbPath = path + "/thumbnails/emisi/" + uid;

        string savePath = "/clients/" + clientid + "/emisi/" + uid;

        if (!Directory.Exists(ujiPath))
        {
            Directory.CreateDirectory(ujiPath);
        }

        if (!Directory.Exists(thumbPath))
        {
            Directory.CreateDirectory(thumbPath);
        }

        foreach (var file in files)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(ujiPath, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if (!fileName.Contains("pdf"))
            {
                Image image = Image.Load(file.OpenReadStream());
                image.Mutate(x => x.Resize(600, 400));

                image.Save(Path.Combine(thumbPath, fileName));
            }
        }

        return savePath;
    }

    public static async Task<string> FotoKendaraan(List<IFormFile> files, string clientid, string uid)
    {
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + clientid);

        string kendaraanPath = path + "/kendaraan/" + uid;

        string thumbPath = path + "/thumbnails/kendaraan/" + uid;

        string savePath = "/clients/" + clientid + "/kendaraan/" + uid;

        if (!Directory.Exists(kendaraanPath))
        {
            Directory.CreateDirectory(kendaraanPath);
        }

        if (!Directory.Exists(thumbPath))
        {
            Directory.CreateDirectory(thumbPath);
        }

        foreach (var file in files)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(kendaraanPath, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if (!fileName.Contains("pdf"))
            {
                Image image = Image.Load(file.OpenReadStream());
                image.Mutate(x => x.Resize(600, 400));

                image.Save(Path.Combine(thumbPath, fileName));
            }
        }

        return savePath;
    }

    public static async Task<string> Kawasan(IFormFile file, string userid)
    {
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + userid);

        string kawasanPath = path + "/kawasan";
        string extIzin = Path.GetExtension(file.FileName);
        string fileNameIzin = FileName.GenerateRandomString().ToLower() + extIzin;

        if (!Directory.Exists(kawasanPath))
        {
            Directory.CreateDirectory(kawasanPath);
        }

        using (FileStream stream = new(Path.Combine(kawasanPath, fileNameIzin), FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        if (!extIzin.Contains("pdf"))
        {
            Image image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(600, 400));

            image.Save(kawasanPath + "/" + "thumbnail-" + fileNameIzin);
        }

        return fileNameIzin;
    }

    public static async Task<string> LokasiAngkut(IFormFile file, string userid)
    {
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + userid);

        string lokasiPath = path + "/lokasi-angkut";
        string extDoc = Path.GetExtension(file.FileName);
        string fileNameDoc = FileName.GenerateRandomString().ToLower() + extDoc;

        if (!Directory.Exists(lokasiPath))
        {
            Directory.CreateDirectory(lokasiPath);
        }

        using (FileStream stream = new(Path.Combine(lokasiPath, fileNameDoc), FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        if (!extDoc.Contains("pdf"))
        {
            Image image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(600, 400));

            image.Save(lokasiPath + "/" + "thumbnail-" + fileNameDoc);
        }

        return fileNameDoc;
    }


}
