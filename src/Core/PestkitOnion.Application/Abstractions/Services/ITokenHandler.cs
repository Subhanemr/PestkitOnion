using PestkitOnion.Application.Dtos.Token;
using PestkitOnion.Domain.Entities;
using System.Security.Claims;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface ITokenHandler
    {
        TokenResponseDto CreateJwt(AppUser user, ICollection<Claim> claims, int minutes);

    }
}
