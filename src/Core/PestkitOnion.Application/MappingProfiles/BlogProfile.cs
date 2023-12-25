using AutoMapper;
using PestkitOnion.Application.Dtos.Blog;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.MappingProfiles
{
    internal class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<CreateBlogDto, Blog>();
            CreateMap<Blog, ItemBlogDto>().ReverseMap();
            CreateMap<GetBlogDto, Blog>().ReverseMap().ForMember(x => x.Tags, opt => opt.Ignore());
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            CreateMap<IncludeBlogDto, Blog>().ReverseMap();

        }
    }
}
