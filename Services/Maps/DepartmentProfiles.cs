using AutoMapper;
using Core.Concrete.DTOs.Department;
using Core.Concrete.Entities;
using Toolbox.Extensions;

namespace Services.Maps
{
    public class DepartmentProfiles : Profile
    {
        public DepartmentProfiles()
        {
            CreateMap<NewDepartmentDTO, Department>()
                .ForMember(
                t => t.Active,
                s => s.MapFrom(src => true))
                .ForMember(
                t => t.Deleted,
                s => s.MapFrom(src => false))
                .ForMember(
                t => t.CreateTime,
                s => s.MapFrom(src => DateTime.Now));

            CreateMap<Department, DepartmentListItemDTO>()
                .ForMember(
                    t => t.Id,
                    s => s.MapFrom(x => x.Id)
                ).ForMember(
                    t => t.Title,
                    s => s.MapFrom(x => x.Title)
                ).ForMember(
                    t => t.Active,
                    s => s.MapFrom(x => x.Active)
                ).ForMember(
                    t => t.Deleted,
                    s => s.MapFrom(x => x.Deleted)
                );
        }
    }
}
