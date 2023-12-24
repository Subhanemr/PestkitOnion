namespace PestkitOnion.Domain.Entities
{
    public class Tag:BaseNameEntity
    {
        //---Relational 
        public ICollection<BlogTag>? BlogTags { get; set; }

    }
}
