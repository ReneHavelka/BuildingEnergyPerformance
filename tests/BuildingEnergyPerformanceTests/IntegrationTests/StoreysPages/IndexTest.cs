using BuildingEnergyPerformanceTests.Common;
using WebUI.Pages.StoreysPages;

namespace BuildingEnergyPerformanceTests.Application.IntegrationTests.StoreysPages
{
	[TestClass]
	public class IndexTest
	{
		[TestMethod]
		public async Task IndexAsync()
		{
			var getContextMapper = new GetContexMapper();
			var context = getContextMapper.Context;
			var mapper = getContextMapper.Mapper;

			var storeys = context.Storeys.OrderBy(x => x.Id).Select(x => new { id = x.Id, name = x.Name }).ToList();

			var indexClass = new IndexModel(context, mapper);
			await indexClass.OnGetAsync();
			var storeysDto = indexClass.StoreyList.OrderBy(x => x.Id).Select(x => new { id = x.Id, name = x.Name }).ToList();

			CollectionAssert.AreEquivalent(storeys, storeysDto);
		}
	}
}
