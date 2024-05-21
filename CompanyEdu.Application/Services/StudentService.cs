using CompanyEdu.Application.Abstraction;
using CompanyEdu.Application.Models;
using CompanyEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyEdu.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IApplicationDbContext _context;

        public StudentService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateStudentModel model)
        {
            var entity = new Student()
            {
                FullName = model.FullName,
                BirtDate = model.BirtDate,
                PhoneNumber = model.PhoneNumber,
                CreateDateTime = DateTime.UtcNow

            };
            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }
            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentViewModel>> GetllAsync()
        {
            return await _context.Students
                .Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    BirthDate = x.BirtDate,
                    PhoneNumber = x.PhoneNumber
                }).ToListAsync();
        }

        public async Task<StudentViewModel> GettByIdAsync(int id)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            return new StudentViewModel()
            {
                Id = entity.Id,
                FullName = entity.FullName,
                BirthDate = entity.BirtDate,
                PhoneNumber = entity.PhoneNumber
            };
        }

        public async Task UpdataAsync(UpdateStudentModel model)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            entity.FullName = model.FullName ?? entity.FullName;
            entity.BirtDate = model.BirthDate ?? entity.BirtDate;
            entity.PhoneNumber = model.PhoneNumber ?? entity.PhoneNumber;

            _context.Students.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

