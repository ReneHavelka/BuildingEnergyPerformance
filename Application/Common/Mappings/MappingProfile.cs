using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Storeys, StoreysDto>().ReverseMap();
            CreateMap<Spaces, SpacesDto>().ReverseMap();
            CreateMap<BuildingElements, BuildingElementsDto>().ReverseMap();
            CreateMap<SpaceTemperatures, SpaceTemperaturesDto>().ReverseMap();
            CreateMap<BuildingElements, BuildingElementsDto>().ReverseMap();
        }
    }
}
