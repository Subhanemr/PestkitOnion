using AutoMapper;
using PestkitOnion.Application.Dtos.Blog;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.MappingProfiles
{
    internal class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<CreateBlogDto, BlogProfile>();
            CreateMap<Blog, ItemBlogDto>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            CreateMap<IncludeBlogDto, Blog>().ReverseMap();

        }
    }
}
