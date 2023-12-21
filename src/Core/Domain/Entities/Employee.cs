namespace PestkitOnion.Domain.Entities
{
    public class Employee:BaseNameEntity
    {
        public string Surname { get; set; } = null!;
        public string? InstLink { get; set; }
        public string? TwitLink { get; set; }
        public string? FaceLink { get; set; }
        public string? LinkedLink { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public Department Department { get; set; } = null!;
        public Position Position { get; set; } = null!;
    }
}
