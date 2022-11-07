using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.ThermalConductivitiesCQR.Commands
{
	public class EditThermalConductivity
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public EditThermalConductivity(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task ModifyThermalConductivity(ThermalConductivitiesDto thermalConductivityDto)
		{
			ThermalConductivities thermalConductivity = _mapper.Map<ThermalConductivities>(thermalConductivityDto);
			_context.ThermalConductivities.Update(thermalConductivity);
			await _context.SaveChangesAsync();
		}
	}
}
