using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.SpaceTemperatureCQR.Queries
{
	public class GetSpaceTemperature
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public GetSpaceTemperature(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public SpaceTemperatureDto GetSpaceTemperatureDto(int id)
		{
			var spaceTemperature = _context.SpaceTemperatures.Find(id);
			var spaceTemperatureDto = _mapper.Map<SpaceTemperatureDto>(spaceTemperature);
			return spaceTemperatureDto;
		}
	}
}
