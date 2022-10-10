using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.ThermalResistancesCQR.Queries
{
	public class GetThermalResistances
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public GetThermalResistances(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public IList<ThermalResistancesDto> GetThermalResistanceDtoList()
		{
			var thermalResistances = _context.ThermalResistanceTable;
			var thermalResistanceDtoList = _mapper.Map<IList<ThermalResistancesDto>>(thermalResistances);
			return thermalResistanceDtoList;
		}
	}
}
