using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.BLL.Common.Services.Attachments
{
    public class AttachmentService : IAttachmentService
    {
        private readonly List<string> _allowedExtensions = new() { ".png", ".jpg", ".jpeg" };


        private const int _allowedMaxSize = 2_097_152; // bytes



        public string? Upload(IFormFile file, string folderName)
        {
            //Get the extension name from the filename (with dot)
            var extension = Path.GetExtension(file.FileName);

            if (!_allowedExtensions.Contains(extension))
            {
                return null;
            }
            if (file.Length > _allowedMaxSize)
            {
                return null;
            }
            //compose the Folder Path
            //var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\{folderName}";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\\\files", folderName);

            if (Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            // compose the file Name
            var fileName = $"{Guid.NewGuid()}{extension}";

            // file location
            var filePath = Path.Combine(folderPath, fileName);


            //stream on this path      and create this file location  (Empty  as free plate)
            using var fileStream = new FileStream(filePath, FileMode.Create);

            // start streaming
            file.CopyTo(fileStream);

            return fileName;
        }
        public bool Delete(string filePath)
        {

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;

        }
    }
}
