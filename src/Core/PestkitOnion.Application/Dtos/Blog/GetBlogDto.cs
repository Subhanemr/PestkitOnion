using PestkitOnion.Application.Dtos.Author;
using PestkitOnion.Application.Dtos.Tag;

namespace PestkitOnion.Application.Dtos.Blog
{
    public record GetBlogDto
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string? Description { get; init; }
        public int CommentCount { get; init; }
        public int AuthorId { get; init; }
        public ICollection<IncludeTagDto> Tags { get; set; }
    }
}
