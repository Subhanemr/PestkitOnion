namespace PestkitOnion.Application.Dtos.Blog
{
    public record CreateBlogDto(string title, string? description, int commentCount, int authorId, ICollection<int> tagIds);
}
