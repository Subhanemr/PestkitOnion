namespace PestkitOnion.Domain.Entities
{
    public class Blog: BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; } 
        public int CommentCount { get; set; }
        //---Relational
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public ICollection<BlogTag> Tags { get; set; } = null!;
    }
}
