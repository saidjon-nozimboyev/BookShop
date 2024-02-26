﻿using Ustoz_Proyekti.BusinessLogic.Interfaces;

namespace Ustoz_Proyekti.BusinessLogic.Services;

public class FileService(IWebHostEnvironment webHostEnvironment)
    : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public void DeleteImage(string fileName)
    {
        var wwwrootFolder = _webHostEnvironment.WebRootPath;
        var filePath = Path.Combine(wwwrootFolder, fileName.Replace("~/", ""));

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public void DeleteMultiple(List<string> fileNames)
    {
        foreach (var fileName in fileNames)
        {
            DeleteImage(fileName);
        }
    }

    public string UploadImage(IFormFile file)
    {
        var wwwrootFolder = _webHostEnvironment.WebRootPath;
        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var filePath = Path.Combine(wwwrootFolder + "/images/", uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        return $"~/images/{uniqueFileName}";
    }

    public List<string> UploadMultipleImageWithoutBg(List<IFormFile> files)
    {
        List<string> urls = new();
        foreach (var file in files)
        {
            var wwwrootFolder = _webHostEnvironment.WebRootPath;
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(wwwrootFolder + "/images/", uniqueFileName);

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Headers.Add("X-Api-Key", "PDrmfo8WiZ2XqgxBVptViiUy");
                var fileBytes = new byte[file.Length];
                file.OpenReadStream().Read(fileBytes, 0, fileBytes.Length);
                Stream stream = new MemoryStream(fileBytes);
                formData.Add(new StreamContent(stream), "image_file", "file.jpg");
                formData.Add(new StringContent("auto"), "size");
                var response = client.PostAsync("https://api.remove.bg/v1.0/removebg", formData).Result;

                if (response.IsSuccessStatusCode)
                {
                    var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                    response.Content.CopyToAsync(fileStream).ContinueWith((copyTask) =>
                    {
                        file.CopyTo(fileStream);
                        fileStream.Close();
                    });

                }
                else
                {
                    Console.WriteLine("Error: " + response.Content.ReadAsStringAsync().Result);
                }
            }

            urls.Add($"~/images/{uniqueFileName}");
        }

        return urls;
    }
}
