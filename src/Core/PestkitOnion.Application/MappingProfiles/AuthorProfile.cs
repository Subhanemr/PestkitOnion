using AutoMapper;
using PestkitOnion.Application.Dtos.Author;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.MappingProfiles
{
    internal class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<Author, ItemAuthorDto>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();
        }
    }
}
