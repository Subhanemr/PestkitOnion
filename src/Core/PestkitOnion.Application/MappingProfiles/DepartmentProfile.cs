using AutoMapper;
using PestkitOnion.Application.Dtos.Department;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.MappingProfiles
{
    internal class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<Department, ItemDepartmentDto>().ReverseMap();
            CreateMap<UpdateDepartmentDto, Department>().ReverseMap();
            CreateMap<GetDepartmentDto, Department>().ReverseMap();
            CreateMap<IncludeDepartmentDto, Department>().ReverseMap();

        }
    }
}
