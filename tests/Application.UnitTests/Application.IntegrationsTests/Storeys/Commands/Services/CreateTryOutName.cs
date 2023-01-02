﻿using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Services
{
	public class CreateTryOutName
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        internal CreateTryOutName(IApplicationDbContext contex, IMapper mapper)
        {
			_context = contex;
            _mapper = mapper;
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
    }
}