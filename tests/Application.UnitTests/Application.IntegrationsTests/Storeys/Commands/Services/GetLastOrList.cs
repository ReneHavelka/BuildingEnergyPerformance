using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Queries;
using AutoMapper;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.CommonServices;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Services
{
    internal class GetLastOrList
	{
		GetStoreys getStoreys;

		internal GetLastOrList()
		{
			GetContexMapper getContexMapper = new();
			IApplicationDbContext context = getContexMapper.Context;
			IMapper mapper = getContexMapper.Mapper;
			getStoreys = new GetStoreys(context, mapper);
		}

		internal async Task<StoreysDto> GetLastStorey()
		{
			var getStoreyDtoList = await getStoreys.GetStoreyDtoListAsync();
			StoreysDto storeysDto = getStoreyDtoList.OrderBy(x => x.Id).LastOrDefault();
			return storeysDto;
		}

		internal async Task<IList<StoreysDto>> GetStoreyList()
		{
			var getStoreyDtoList = await getStoreys.GetStoreyDtoListAsync();
			IList<StoreysDto> storeyList = getStoreyDtoList.OrderBy(x => x.Id).ToList();
			return storeyList;
		}
	}
}
