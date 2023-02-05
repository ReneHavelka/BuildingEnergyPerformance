using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ThermalResistancesCQR.Commands
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

		public async Task AddThermalResistanceAsync(ThermalResistancesDto thermalResistanceDto)
		{
			ThermalResistances thermalResistance = _mapper.Map<ThermalResistances>(thermalResistanceDto);
			await _context.ThermalResistances.AddAsync(thermalResistance);
			await _context.SaveChangesAsync();
		}
	}
}
