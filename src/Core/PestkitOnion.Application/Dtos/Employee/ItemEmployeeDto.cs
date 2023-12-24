namespace PestkitOnion.Application.Dtos.Employee
{
    public record ItemEmployeeDto(int id, string name, string surname,
        string? instLink, string? twitLink, string? faceLink, string? linkedLink, int departmentId, int positionId);
}
