using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Common.Services
{
    public class AttachmentService : IAttachService
    {
        private readonly List<string> AllowedExtensions = new() { ".jpg", ".jpeg", ".png" };
        private const int FileMaxSize = 2_097_152; //2Mbs
        
        public string UploadFile(IFormFile file, string folderName)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            if (!AllowedExtensions.Contains(fileExtension))
            {
                throw new Exception("Invalid File Extension Please Try Again !!");
            }
            if (file.Length >FileMaxSize)
            {
                throw new Exception("Invalid File Size");   
            }

            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            var fileName = $"{Guid.NewGuid()}{fileExtension}";

            var filePath = Path.Combine(FolderPath, fileName);


            using var FileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(FileStream);
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
