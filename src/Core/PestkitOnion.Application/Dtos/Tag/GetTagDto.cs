using PestkitOnion.Application.Dtos.Blog;

namespace PestkitOnion.Application.Dtos.Tag
{
    public record GetTagDto {

        public int Id { get; init; }
        public string Name { get; init; }
        public ICollection<IncludeBlogDto>? Blogs { get; set; }     
    }
}
