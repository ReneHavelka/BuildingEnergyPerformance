using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Common
{
	public class CreateTryOutName
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        internal CreateTryOutName()
        {
            GetContexMapper getContexMapper = new();
			_context = getContexMapper.Context;
            _mapper = getContexMapper.Mapper;
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
