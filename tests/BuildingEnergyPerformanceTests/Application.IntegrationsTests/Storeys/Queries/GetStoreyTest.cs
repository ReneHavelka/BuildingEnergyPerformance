using Application.StoreysCQR.Queries;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Queries
{
	[TestClass]
	public class GetStoreyTest
	{
		[TestMethod]
		public async Task CompareNameAsync()
		{
			var getContextMapper = new GetContexMapper();
			var context = getContextMapper.Context;
			var mapper = getContextMapper.Mapper;

			//Item form database
			var storey = context.Storeys.FirstOrDefault();
			var name = storey.Name;
			var id = storey.Id;

			//Item by application query
			var getStorey = new GetStorey(context, mapper);
			var getStoreyDtoAsync = getStorey.GetStoreyDtoAsync(id);
			var storeyDto = await getStoreyDtoAsync;
			var nameDto = storeyDto.Name;

			Assert.AreEqual(name, nameDto);

		}
	}
}
