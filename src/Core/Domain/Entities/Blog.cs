namespace PestkitOnion.Domain.Entities
{
    public class Blog: BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; } 
        //---Relational
        public int AuthorId { get; set; }
        public int CommentCount { get; set; }
        public Author? Author { get; set; }
        public ICollection<BlogTag>? Tags { get; set; }
    }
}
