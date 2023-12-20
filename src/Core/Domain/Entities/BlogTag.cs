namespace PestkitOnion.Domain.Entities
{
    public class BlogTag: BaseEntity
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public Blog Blog { get; set; } = null!;
        public Tag Tag { get; set; } = null!;
    }
}
