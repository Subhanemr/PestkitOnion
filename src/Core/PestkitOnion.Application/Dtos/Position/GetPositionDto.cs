using PestkitOnion.Application.Dtos.Employee;

namespace PestkitOnion.Application.Dtos.Position
{
    public record GetPositionDto(int id, string name, ICollection<IncludeEmployeeDto> employees);
}
