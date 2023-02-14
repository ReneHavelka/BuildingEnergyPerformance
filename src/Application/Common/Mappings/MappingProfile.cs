using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Storey, StoreyDto>().ReverseMap();
			CreateMap<Space, SpaceDto>().ReverseMap();
			CreateMap<BuildingElement, BuildingElementDto>().ReverseMap();
			CreateMap<Layer, LayerDto>().ReverseMap();
			CreateMap<SpaceTemperature, SpaceTemperatureDto>().ReverseMap();
			CreateMap<BuildingElement, BuildingElementDto>().ReverseMap();
			CreateMap<ThermalConductivity, ThermalConductivitieDto>().ReverseMap();
			CreateMap<ThermalResistance, ThermalResistanceDto>().ReverseMap();
		}
	}
}
