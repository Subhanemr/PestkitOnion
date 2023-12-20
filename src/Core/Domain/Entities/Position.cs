namespace PestkitOnion.Domain.Entities
{
    public class Position:BaseNameEntity
    {
        public ICollection<Employee>? Employees { get; set; }

    }
}
