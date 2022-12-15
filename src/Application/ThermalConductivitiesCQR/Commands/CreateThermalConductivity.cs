using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.ThermalConductivitiesCQR.Commands
{
	public class CreateThermalConductivity
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public CreateThermalConductivity(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task AddThermalConductivity(ThermalConductivitiesDto thermalConductivityDto)
		{
			ThermalConductivities thermalConductivity = _mapper.Map<ThermalConductivities>(thermalConductivityDto);
			await _context.ThermalConductivities.AddAsync(thermalConductivity);
			await _context.SaveChangesAsync();
		}
	}
}
