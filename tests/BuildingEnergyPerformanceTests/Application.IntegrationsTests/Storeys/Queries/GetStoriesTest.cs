using Application.StoreysCQR.Queries;
using BuildingEnergyPerformanceTests.CommonServices;
using System.Collections;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Queries
{
	[TestClass]
	public class GetStoriesTest
	{
		[TestMethod]
		public async Task CompareNamesAsync()
		{
			var getContextMapper = new GetContexMapper();
			var context = getContextMapper.Context;
			var mapper = getContextMapper.Mapper;

			//Names form database to list.
			var storeyNames = context.Storeys.OrderBy(x => x.Name).Select(y => y.Name).ToList() as ICollection;

			//Names by the means of application query
			var getStoreys = new GetStoreys(context, mapper);
			var getStoreyDtoListAsync = getStoreys.GetStoreyDtoListAsync();
			var storeysDto = await getStoreyDtoListAsync;
			var storeyNamesDto = storeysDto.OrderBy(x => x.Name).Select(y => y.Name).ToList() as ICollection;

			CollectionAssert.AreEquivalent(storeyNames, storeyNamesDto);
		}

	}
}
