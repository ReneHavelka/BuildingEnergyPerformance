﻿using Application.Common.Interfaces;
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
	internal class EditTryOutName
	{


		IApplicationDbContext _context;
		IMapper _mapper;
		internal string OriginalName { get; set; }
		internal bool HasFinished { get; set; }

		internal EditTryOutName(IApplicationDbContext contex, IMapper mapper)
		{
			_context = contex;
			_mapper = mapper;
		}

		public async Task TryName(string str)
		{
			var getLastOrList = new GetLastOrList();
			StoreysDto storeyDto = await getLastOrList.GetLastStorey();
			//The id is gotten from the last storey record.
			var id = storeyDto.Id;
			//Name of the last storey record - origianl name.
			OriginalName = storeyDto.Name;

			storeyDto.Name = str;
			storeyDto.Id = id;

			try
			{
				var editStorey = new EditStorey(_context, _mapper);
				await editStorey.ModifyStorey(storeyDto);
			}
			catch
			{
				throw;
			}
		}
	}
}
