namespace PestkitOnion.Domain.Entities
{
    public class Project:BaseNameEntity
    {
        public ICollection<ProjectImage> ProjectImages { get; set; } = null!;

    }
}
