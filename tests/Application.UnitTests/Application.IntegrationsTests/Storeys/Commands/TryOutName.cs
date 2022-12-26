using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands
{
	public class TryOutName
	{
		IApplicationDbContext _context;
		IMapper _mapper;
		
		internal TryOutName()
		{
			_context = new ApplicationDbContext();

			var mappingProfile = new MappingProfile();
			var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
			_mapper = new Mapper(config);
		}

		internal async Task TryName(string str)
		{
			StoreysDto storeyDto = new();
			CreateStorey createStorey = new(_context, _mapper);
			storeyDto.Name = str;

			try
			{
				await createStorey.AddStorey(storeyDto);
			}
			catch
			{
				throw;
			}
		}

		public async Task TryName(string str, int id)
		{
			StoreysDto storeyDto = new();
			EditStorey editStorey = new(_context, _mapper);
			storeyDto.Name = str;
			
			storeyDto.Id = id;

			try
			{
				await editStorey.ModifyStorey(storeyDto);
			}
			catch
			{
				throw;
			}
		}


	}
}
