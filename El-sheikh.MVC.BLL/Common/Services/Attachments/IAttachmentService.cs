using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.BLL.Common.Services.Attachments
{
    public interface IAttachmentService
    {


        Task<string?> UploadAsync(IFormFile file,string folderName);


        bool Delete(string filePath);
    }
}
