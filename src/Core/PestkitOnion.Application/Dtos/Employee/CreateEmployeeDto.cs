namespace PestkitOnion.Application.Dtos.Employee
{
    public record CreateEmployeeDto(string name, string surname,
        string? instLink, string? twitLink, string? faceLink, string? linkedLink, int departmentId, int positionId);
}
