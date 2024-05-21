using CompanyEdu.Application.Models;

namespace CompanyEdu.Application.Abstraction
{
    public interface IGroupService
    {
        Task<GroupViewModel> GettByIdAsync(int id);

        Task<List<GroupViewModel>> GetllAsync();

        Task CreateAsync(CreateGroupModel model);

        Task UpdataAsync(UpdateGroupModel model);

        Task DeleteAsync(int id);

        Task AddStudentAsync(int groupId, AddStudentModel model);

        Task RemoveStudentAsync(int studentId, int groupId);

        Task<List<LessonViewModel>> GetLessonsAsync(int groupId);

    }
}
