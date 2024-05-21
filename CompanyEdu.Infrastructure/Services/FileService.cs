using CompanyEdu.Application.Abstraction;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEdu.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> Upload(IFormFile formFile)
        {
            var FileNameItems = formFile.FileName.Split('.');
            var extension = FileNameItems[FileNameItems.Length - 1];
            var fileName = formFile.FileName.Remove(formFile.FileName.IndexOf(extension, StringComparison.InvariantCultureIgnoreCase));
            
            var path = $"/Files/{fileName}-{Guid.NewGuid()}.{extension}";

            var fullPath = _webHostEnvironment.WebRootPath + path;

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }

            return path;
        }
    }
}
