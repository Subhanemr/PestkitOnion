using AutoMapper;
using PestkitOnion.Application.Dtos.Tag;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.MappingProfiles
{
    internal class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<CreateTagDto, Tag>();
            CreateMap<Tag, ItemTagDto>().ReverseMap();
            CreateMap<UpdateTagDto, Tag>().ReverseMap();
            CreateMap<GetTagDto, Tag>().ReverseMap().ForMember(x => x.Blogs, opt => opt.Ignore());
            CreateMap<IncludeTagDto, Tag>().ReverseMap();


        }
    }
}
