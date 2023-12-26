using AutoMapper;
using PestkitOnion.Application.Dtos.Account;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.MappingProfiles
{
    internal class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AppUser, LogInDto>().ReverseMap();
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}
