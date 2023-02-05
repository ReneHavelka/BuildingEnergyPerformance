using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.ThermalResistancesCQR.Queries
{
	public class GetThermalResistance
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public GetThermalResistance(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ThermalResistancesDto> GetThermalResistanceDtoAsync(int id)
		{
			var thermalResistance = await _context.ThermalResistances.FindAsync(id);
			var thermalResistanceDto = _mapper.Map<ThermalResistancesDto>(thermalResistance);
			return thermalResistanceDto;
		}
	}
}
