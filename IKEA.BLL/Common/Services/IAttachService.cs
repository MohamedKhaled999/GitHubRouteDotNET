using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Common.Services
{
    public interface IAttachService
    {
        string UploadFile (IFormFile file, string folderName);
        bool Delete(string filePath);


    }
}
