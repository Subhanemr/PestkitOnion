namespace PestkitOnion.Application.Dtos.Employee
{
    public record IncludeEmployeeDto(int id, string name, string surname, 
        string? instLink, string? twitLink, string? faceLink, string? linkedLink);
}
