namespace PestkitOnion.Application.Dtos.Blog
{
    public record UpdateBlogDto(string title, string? description, int commentCount, int authorId, ICollection<int> tagIds);
}
