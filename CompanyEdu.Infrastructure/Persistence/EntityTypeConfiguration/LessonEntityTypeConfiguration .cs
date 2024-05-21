using CompanyEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEdu.Infrastructure.Persistence.EntityTypeConfiguration
{
    public class LessonEntityTypeConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Group)
                .WithMany(p => p.Lessons)
                .HasForeignKey(p => p.GroupId);

        }
    }
}
