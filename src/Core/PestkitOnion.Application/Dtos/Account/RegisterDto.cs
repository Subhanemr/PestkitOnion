namespace PestkitOnion.Application.Dtos.Account
{
    public record RegisterDto(string UserName, string Name, string Surname, string Email, string Password, string ConfirmPassword);
}
