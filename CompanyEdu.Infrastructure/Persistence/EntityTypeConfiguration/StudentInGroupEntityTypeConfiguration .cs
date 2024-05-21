using CompanyEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEdu.Infrastructure.Persistence.EntityTypeConfiguration
{
    public class StudentInGroupEntityTypeConfiguration : IEntityTypeConfiguration<StudentInGroup>
    {
        public void Configure(EntityTypeBuilder<StudentInGroup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Student)
                .WithMany(p => p.StudentInGroups)
                .HasForeignKey(p => p.StudentId);

            builder.HasOne(p => p.Group)
                .WithMany(p => p.GroupStudents)
                .HasForeignKey(p => p.GroupId);

        }
    }
}
