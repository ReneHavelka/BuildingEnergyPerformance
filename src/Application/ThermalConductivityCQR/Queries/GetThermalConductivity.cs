using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.ThermalConductivityCQR.Queries
{
	public class GetThermalConductivity
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public GetThermalConductivity(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ThermalConductivitieDto GetThermalConductivityDto(int id)
		{
			var thermalConductivity = _context.ThermalConductivities.Find(id);
			var thermalConductivityDto = _mapper.Map<ThermalConductivitieDto>(thermalConductivity);
			return thermalConductivityDto;
		}
	}
}
