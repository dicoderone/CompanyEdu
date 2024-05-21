using CompanyEdu.Application.Models;

namespace CompanyEdu.Application.Abstraction
{
    public interface IAttendanceService
    {
        Task CheckAsync(DoAttendanceCheckModel model);
    }
}
