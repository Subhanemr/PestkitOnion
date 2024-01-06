using PestkitOnion.Application.Dtos.Account;
using PestkitOnion.Application.Dtos.Token;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterDto register);
        Task<TokenResponseDto> LogInAsync(LogInDto login);
        Task<TokenResponseDto> LogInByRefreshToken(string refresh);
    }
}
