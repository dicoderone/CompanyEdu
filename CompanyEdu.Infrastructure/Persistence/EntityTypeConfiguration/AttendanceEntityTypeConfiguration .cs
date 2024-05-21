using CompanyEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEdu.Infrastructure.Persistence.EntityTypeConfiguration
{
    public class AttendanceEntityTypeConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Lesson)
                .WithMany(p => p.Attendances)
                .HasForeignKey(p => p.LessonId);

            builder.HasOne(p => p.Student)
                .WithMany(p => p.Attendances)
                .HasForeignKey(p => p.StudentId);
        }
    }
}
