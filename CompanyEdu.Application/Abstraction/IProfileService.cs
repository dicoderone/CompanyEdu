using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEdu.Application.Abstraction
{
    public interface IProfileService
    {
        Task SetPhoto(IFormFile formFile);
    }
}
