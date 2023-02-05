using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.ThermalResistancesCQR.Commands
{
	public class EditThermalResistance
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public EditThermalResistance(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task ModifyThermalResistanceAsync(ThermalResistancesDto thermalResistanceDto)
		{
			var thermalResistance = _mapper.Map<ThermalResistances>(thermalResistanceDto);
			_context.ThermalResistances.Update(thermalResistance);
			Task saveChanges = _context.SaveChangesAsync();
			await saveChanges;
		}
	}
}
