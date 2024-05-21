using CompanyEdu.Domain.Entities;

namespace CompanyEdu.Infrastructure.Abstractions
{
    public interface ITokenService
    {
        string GeneratAccessToken(User user);
    }
}
