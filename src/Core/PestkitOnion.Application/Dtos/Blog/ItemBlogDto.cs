namespace PestkitOnion.Application.Dtos.Blog
{
    public record ItemBlogDto(int id, string title, string? description, int commentCount, int authorId);
}
