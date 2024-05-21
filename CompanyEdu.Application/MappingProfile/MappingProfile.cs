using AutoMapper;
using CompanyEdu.Application.Abstraction;
using CompanyEdu.Application.Models;
using CompanyEdu.Domain.Entities;
using CompanyEdu.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEdu.Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IHashProvider hashProvider)
        {
            CreateMap<User, TeacherViewModel>();
            /*CreateMap<User,TeacherViewModel>()
                .ForMember(x => x.UserName, o => o.MapFrom(s => s.UserName));*/

            CreateMap<CreateTeacherModel, User>()
                .ForMember(x => x.Role, o => o.MapFrom(s => UserRole.Teacher))
                .ForMember(d => d.PasswordHash, o => o.MapFrom(s => hashProvider.GetHash(s.Password)));

            CreateMap<UpdateTeacherModel, User>()
                .BeforeMap((model, entity, context) =>
                {
                    entity.PasswordHash = model.Password == null ? entity.PasswordHash :hashProvider.GetHash(model.Password);

                });
        }
    } 
}
