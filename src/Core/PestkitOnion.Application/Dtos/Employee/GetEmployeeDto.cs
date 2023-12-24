using PestkitOnion.Application.Dtos.Department;
using PestkitOnion.Application.Dtos.Position;

namespace PestkitOnion.Application.Dtos.Employee
{
    public record GetEmployeeDto(int id, string name, string surname,
        string? instLink, string? twitLink, string? faceLink, string? linkedLink, int departmentId, int positionId, 
        IncludeDepartmentDto department, IncludePositionDto position);
}
