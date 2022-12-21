using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands
{
	[TestClass]
	public class EditStoreyTests
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public EditStoreyTests()
		{
			_context = new ApplicationDbContext();

			var mappingProfile = new MappingProfile();
			var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
			_mapper = new Mapper(config);
		}

		public async Task TryName(string str)
		{
			StoreysDto storeyDto = new();
			EditStorey editStorey = new(_context, _mapper);
			storeyDto.Name = str;
			//var id = _context.Storeys.OrderBy(x => x.Id).LastOrDefault().Id;
			storeyDto.Id = 11;

			//The id is gotten from the first record.

			try
			{
				await editStorey.ModifyStorey(storeyDto);
			}
			catch (Exception ex)
			{
				throw new ArgumentException(ex.Message);
			}
		}




	}
}
