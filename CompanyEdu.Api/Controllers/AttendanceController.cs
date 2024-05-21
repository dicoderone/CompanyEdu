using CompanyEdu.Application.Abstraction;
using CompanyEdu.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttendanceController : ControllerBase
    {
        public readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost("check")]
        public async Task<IActionResult> AttendanceCheck(DoAttendanceCheckModel model)
        {
            await _attendanceService.CheckAsync(model);

            return Ok();
        }
    }
}
