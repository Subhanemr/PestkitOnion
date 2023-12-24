namespace PestkitOnion.Domain.Entities
{
    public class Department: BaseNameEntity
    {
        //---Relational
        public ICollection<Employee> Employees { get; set; }
    }
}
