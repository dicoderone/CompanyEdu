using CompanyEdu.Application.Models;

namespace CompanyEdu.Application.Abstraction
{
    public interface IStudentService
    {
        Task<StudentViewModel> GettByIdAsync(int id);

        Task<List<StudentViewModel>> GetllAsync();

        Task CreateAsync(CreateStudentModel model);

        Task UpdataAsync(UpdateStudentModel model);

        Task DeleteAsync(int id);
    }
}
