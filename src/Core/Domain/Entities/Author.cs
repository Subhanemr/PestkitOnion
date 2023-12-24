namespace PestkitOnion.Domain.Entities
{
    public class Author:BaseNameEntity
    {
        public string Surname { get; set; } = null!;
        
        //---Relational
        public ICollection<Blog>? Blogs { get; set; }
    }
}
