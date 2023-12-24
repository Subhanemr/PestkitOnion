using PestkitOnion.Application.Dtos.Blog;

namespace PestkitOnion.Application.Dtos.Author
{
    public record GetAuthorDto(int id, string name, string surname, ICollection<IncludeBlogDto> blogs);
}
