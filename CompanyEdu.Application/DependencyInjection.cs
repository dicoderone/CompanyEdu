using AutoMapper;
using CompanyEdu.Application.Abstraction;
using CompanyEdu.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using CompanyEdu.Application.MappingProfile;

namespace CompanyEdu.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
           
            services.AddSingleton(provider => new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile.MappingProfile(provider.GetRequiredService<IHashProvider>()));
            }).CreateMapper());

            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IAttendanceService, AttendanceService>();

            return services;
        }
    }
}
