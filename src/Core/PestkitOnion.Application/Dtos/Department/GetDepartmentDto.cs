using PestkitOnion.Application.Dtos.Employee;

namespace PestkitOnion.Application.Dtos.Department
{
    public record GetDepartmentDto(int id, string name, ICollection<IncludeEmployeeDto> employees);
}
