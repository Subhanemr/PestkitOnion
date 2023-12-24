namespace PestkitOnion.Domain.Entities
{
    public class Project:BaseNameEntity
    {
        //---Relational
        public ICollection<ProjectImage> ProjectImages { get; set; } = null!;

    }
}
