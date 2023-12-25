using PestkitOnion.Application.Dtos.Author;
using PestkitOnion.Application.Dtos.Tag;

namespace PestkitOnion.Application.Dtos.Blog
{
    public record GetBlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int CommentCount { get; set; }
        public int AuthorId { get; set; }
        public ICollection<IncludeTagDto> Tags { get; set; }
    }
}
