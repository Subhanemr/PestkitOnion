using AutoMapper;
using PestkitOnion.Application.Dtos.Project;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.MappingProfiles
{
    internal class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<CreateProjectDto, Project>();
            CreateMap<Project, ItemProjectDto>().ReverseMap();
            CreateMap<UpdateProjectDto, Project>().ReverseMap();
        }
    }
}
