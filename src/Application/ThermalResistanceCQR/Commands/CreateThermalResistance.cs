using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.ThermalResistanceCQR.Commands
{
	public class CreateThermalResistance
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public CreateThermalResistance(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task AddThermalResistanceAsync(ThermalResistanceDto thermalResistanceDto)
		{
			ThermalResistance thermalResistance = _mapper.Map<ThermalResistance>(thermalResistanceDto);
			await _context.ThermalResistances.AddAsync(thermalResistance);
			await _context.SaveChangesAsync();
		}
	}
}
