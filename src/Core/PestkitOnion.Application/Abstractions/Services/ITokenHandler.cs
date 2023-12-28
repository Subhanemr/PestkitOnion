using PestkitOnion.Application.Dtos.Token;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface ITokenHandler
    {
        TokenResponseDto CreateJwt(AppUser user, int minutes);
    }
}
