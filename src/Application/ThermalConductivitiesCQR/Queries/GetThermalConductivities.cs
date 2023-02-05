using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ThermalConductivitiesCQR.Queries
{
	public class GetThermalConductivities
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public GetThermalConductivities(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public IList<ThermalConductivitiesDto> GetThermalConductivitiesDtoList()
		{
			var thermalConductivities = _context.ThermalConductivities;
			var thermalConductivitiesDtoList = _mapper.Map<IList<ThermalConductivitiesDto>>(thermalConductivities);
			return thermalConductivitiesDtoList;
		}
	}
}
