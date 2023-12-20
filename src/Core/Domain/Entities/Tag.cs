namespace PestkitOnion.Domain.Entities
{
    public class Tag:BaseNameEntity
    {
        public ICollection<BlogTag>? BlogTags { get; set; }

    }
}
