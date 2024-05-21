using CompanyEdu.Domain.Entities;
using CompanyEdu.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEdu.Infrastructure.Persistence.EntityTypeConfiguration
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(x => x.UserName)
                .IsUnique();

            builder.HasData(new User
            {
                Id = 1,
                UserName = "Admin1",
                PasswordHash = "0973AE8A344EBED06413F630F8E9B2DE0BAEFD310D226D6EFC123FC7E98D66BB006585AAFD5DA15EAB0E473A8F03192B651B09EA0B71E758931219543753CBA1",
                Role = UserRole.Admin,
                FullName = "Kali Admin",

            });
        }
    }
}
