using AutoMapper;
using PestkitOnion.Application.Dtos.Employee;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.MappingProfiles
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, ItemEmployeeDto>().ReverseMap();
            CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();
        }
    }
}
