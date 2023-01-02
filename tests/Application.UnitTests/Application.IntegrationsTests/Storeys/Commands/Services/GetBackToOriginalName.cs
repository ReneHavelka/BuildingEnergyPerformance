using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Services
{
	internal class GetBackToOriginalName
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		internal GetBackToOriginalName(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		internal async Task ToOriginalName(StoreysDto storeyDto)
		{
			var editStorey = new EditStorey(_context, _mapper);
			await editStorey.ModifyStorey(storeyDto);
		}
	}
}
