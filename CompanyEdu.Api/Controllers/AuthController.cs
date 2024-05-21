using CompanyEdu.Api.Models;
using CompanyEdu.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest requset)
        {
            var token = await _authService.LoginAsync(requset.UserName, requset.Password);

            return Ok(token);
        }

    }
}
