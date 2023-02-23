﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

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

    public static async Task STNK(List<IFormFile> files, Guid clientID, string id)
    {
		foreach (var file in files)
		{
			string wwwPath = Uploads.Path;
			string path = Path.Combine(wwwPath, @"clients/" + clientID.ToString() + "/stnk/" + id);

			//create folder if not exist
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			//get file extension
			FileInfo fileInfo = new FileInfo(file.FileName);
			string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

			string fileNameWithPath = Path.Combine(path, fileName);

			using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

		}
	}

	public static async Task KIR(List<IFormFile> files, Guid clientID, string id)
	{
		foreach (var file in files)
		{
			string wwwPath = Uploads.Path;
			string path = Path.Combine(wwwPath, @"clients/" + clientID.ToString() + "/kir/" + id);

			//create folder if not exist
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			//get file extension
			FileInfo fileInfo = new FileInfo(file.FileName);
			string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

			string fileNameWithPath = Path.Combine(path, fileName);

			using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

		}
	}

    public static async Task FotoKendaraan(List<IFormFile> files, Guid clientID, string id)
    {
        foreach (var file in files)
        {
            string wwwPath = Uploads.Path;
            string path = Path.Combine(wwwPath, @"clients/" + clientID.ToString() + "/kendaraan/" + id);

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

        }
    }

    public static async Task UjiEmisi(List<IFormFile> files, Guid clientID, string id)
    {
        foreach (var file in files)
        {
            string wwwPath = Uploads.Path;
            string path = Path.Combine(wwwPath, @"clients/" + clientID.ToString() + "/ujiemisi/" + id);

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

        }
    }
}
