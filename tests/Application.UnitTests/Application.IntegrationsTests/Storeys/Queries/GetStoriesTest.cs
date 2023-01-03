using Application.StoreysCQR.Queries;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.CommonServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			var storeysDto = await getStoreys.GetStoreyDtoListAsync();
			var storeyNamesDto = storeysDto.OrderBy(x => x.Name).Select(y => y.Name).ToList() as ICollection;

			CollectionAssert.AreEquivalent(storeyNames, storeyNamesDto);
		}

	}
}
