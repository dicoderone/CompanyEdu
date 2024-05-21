using CompanyEdu.Application.Abstraction;
using CompanyEdu.Application.Models;
using CompanyEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyEdu.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IApplicationDbContext _context;

        public AttendanceService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CheckAsync(DoAttendanceCheckModel model)
        {
            /*var lessons = await _context.Lessons.Include(x => x.Group).FirstOrDefaultAsync(x => x.Id == model.LessonId);

            if (lessons == null || lessons.Group.TeacherId != _currentUserService.UserId)
            {
                throw new Exception("Not found");
            }*/

            var groupStudent = await _context.Lessons
                .Where(x => x.Id == model.LessonId)
                .Include(x => x.Group)
                .ThenInclude(x => x.GroupStudents)
                .SelectMany(x => x.Group.GroupStudents)
                .Select(x => x.StudentId).ToListAsync();

            var attendanceList = new List<Attendance>();

            foreach (var studentId in groupStudent)
            {
                var check = model.Checks.FirstOrDefault(x => x.studentId == studentId);

                var attendance = new Attendance()
                {
                    StudentId = studentId,
                    LessonId = model.LessonId,
                    HasParticipated = false,
                };

                if (check != null)
                {
                    attendance.HasParticipated = check.HasParticipated;
                }

                attendanceList.Add(attendance);
            }

            _context.Attendances.AddRange(attendanceList);
            await _context.SaveChangesAsync();
        }
    }
}
