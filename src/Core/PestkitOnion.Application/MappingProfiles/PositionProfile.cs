using AutoMapper;
using PestkitOnion.Application.Dtos.Position;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Application.MappingProfiles
{
    internal class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<CreatePositionDto, Position>();
            CreateMap<Position, ItemPositionDto>().ReverseMap();
            CreateMap<UpdatePositionDto, Position>().ReverseMap();
            CreateMap<GetPositionDto, Position>().ReverseMap();

        }
    }
}
