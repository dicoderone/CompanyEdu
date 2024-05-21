using CompanyEdu.Application.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEdu.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IFileService _fileService;
        private readonly IApplicationDbContext _dbContext;

        public ProfileService(IFileService fileService, IApplicationDbContext applicationDbContext)
        {
            _fileService = fileService;
            _dbContext = applicationDbContext;

        }

        public async Task SetPhoto(IFormFile formFile)
        {
            var path =  await _fileService.Upload(formFile);  
        }
    }
}
