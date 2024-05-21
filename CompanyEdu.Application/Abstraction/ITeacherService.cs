using CompanyEdu.Application.Models;

namespace CompanyEdu.Application.Abstraction
{
    public interface ITeacherService
    {
        Task<TeacherViewModel> GettByIdAsync(int id);

        Task<List<TeacherViewModel>> GetllAsync();

        Task CreateAsync(CreateTeacherModel model);

        Task UpdataAsync(UpdateTeacherModel model);

        Task DeleteAsync(int id);
    } 
}
