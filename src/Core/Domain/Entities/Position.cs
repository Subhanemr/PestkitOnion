namespace PestkitOnion.Domain.Entities
{
    public class Position:BaseNameEntity
    {
        //---Relational
        public ICollection<Employee>? Employees { get; set; }

    }
}
