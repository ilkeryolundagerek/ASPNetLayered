using AutoMapper;
using Core.Concrete.DTOs.Department;
using Core.Concrete.DTOs.Person;
using Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Maps
{
    public class PersonProfiles : Profile
    {
        public PersonProfiles()
        {
            CreateMap<Person, PersonListItemDTO>()
                .ForMember(
                t => t.Fullname,
                s => s.MapFrom(src => $"{src.Firstname} {src.Middlename} {src.Lastname}"))
                .ForMember(
                t => t.DepartmentName,
                s => s.MapFrom(src => src.Department.Title));

            CreateMap<NewPersonDTO, Person>()
               .ForMember(
               t => t.Active,
               s => s.MapFrom(src => true))
               .ForMember(
               t => t.Deleted,
               s => s.MapFrom(src => false))
               .ForMember(
               t => t.CreateTime,
               s => s.MapFrom(src => DateTime.Now));
        }

    }
}
