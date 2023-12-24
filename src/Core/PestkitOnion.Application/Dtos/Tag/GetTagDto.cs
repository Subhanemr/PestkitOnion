using PestkitOnion.Application.Dtos.Blog;

namespace PestkitOnion.Application.Dtos.Tag
{
    public record GetTagDto(int id, string name, ICollection<IncludeBlogDto> blogs);
}
