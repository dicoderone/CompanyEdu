using AutoMapper;
using CompanyEdu.Application.Abstraction;
using CompanyEdu.Application.Models;
using CompanyEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyEdu.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GroupService(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task CreateAsync(CreateGroupModel model)
        {
            var entity = new Group()
            {
                Name = model.Name,
                TeacherId = model.TeacherId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,

            };
            _context.Groups.Add(entity);

            var lessons = new List<Lesson>();

            var totalDaysFromStartToEnd = (entity.EndDate - entity.StartDate).Days;

            var currentDate = entity.StartDate;
            for (int i = 1; i <= totalDaysFromStartToEnd; i++)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var lesson = new Lesson()
                    {
                        Group = entity,
                        StartDateTime = currentDate.Date + model.LessonStartTime,
                        EndDateTime = currentDate.Date + model.LessonEndTime,
                    };

                    lessons.Add(lesson);
                }
                currentDate = currentDate.AddDays(1);
            }

            _context.Lessons.AddRange(lessons);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }
            _context.Groups.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GroupViewModel>> GetllAsync()
        {
            return await _context.Groups
                .Select(x => new GroupViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    TeacherId = x.TeacherId,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate,
                }).ToListAsync();
        }

        public async Task<GroupViewModel> GettByIdAsync(int id)
        {
            var entity = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);

            return new GroupViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                TeacherId = entity.TeacherId,
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
            };
        }

        public async Task UpdataAsync(UpdateGroupModel model)
        {
            var entity = await _context.Groups.Include(x => x.Lessons).FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            entity.Name = model.Name ?? entity.Name;
            entity.TeacherId = model.TeacherId ?? entity.TeacherId;

            _context.Groups.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveStudentAsync(int studentId, int groupId)
        {

            var entity = await _context.StudentsGroups.FirstOrDefaultAsync(x => x.Id == studentId && x.GroupId == groupId);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _context.StudentsGroups.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LessonViewModel>> GetLessonsAsync(int groupId)
        {
            var lessons = await _context.Lessons.Where(x => x.GroupId == groupId)
                .Select(x => new LessonViewModel()
                {
                    Id = x.Id,
                    GroupId = x.GroupId,
                    StartDateTime = x.StartDateTime,
                    EndDateTime = x.EndDateTime,
                }).ToListAsync();

            return lessons;
        }

        public async Task AddStudentAsync(int groupId, AddStudentModel model)
        {
            if (!await _context.Students.AnyAsync(x => x.Id == model.studentId))
            {
                throw new Exception("Not found");
            }

            if (!await _context.Groups.AnyAsync(x => x.Id == groupId))
            {
                throw new Exception("Not found");
            }

            var studentGroup = new StudentInGroup()
            {
                GroupId = groupId,
                StudentId = model.studentId,
                IsPayed = model.isPayed,
                JoinedDate = model.JoinedDate,
            };

            _context.StudentsGroups.Add(studentGroup);
            await _context.SaveChangesAsync();
        }
    }
}
