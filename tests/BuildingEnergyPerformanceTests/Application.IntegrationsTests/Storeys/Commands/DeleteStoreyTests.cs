using Application.Common.Models;
using Application.StoreysCQR.Commands;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Services;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.CommonServices;
using System.Collections;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands
{
	[TestClass]
	public class DeleteStoreyTests
	{
		[TestMethod]
		public async Task DeleteStorey()
		{
			var getContextMapper = new GetContexMapper();
			var context = getContextMapper.Context;
			var mapper = getContextMapper.Mapper;
			var getLastOrList = new GetLastOrList();

			//Name list before adding and deleting
			Task<IList<StoreysDto>> getStoreyListAsync = getLastOrList.GetStoreyListAsync();
			var storeyListBefore = await getStoreyListAsync;
			var nameListBefore = storeyListBefore.Select(x => x.Name).ToList() as ICollection;

			//Add a new storey.
			string name = "DeleteTest";
			var createTryOutName = new CreateTryOutName(context, mapper);
			Task tryName = createTryOutName.TryNameAsync(name);
			await tryName;

			//Checking whether the new name has been added.
			//Last record in storey database
			var getLastStoreyAsync =  getLastOrList.GetLastStoreyAsync();
			var addedStorey = await getLastStoreyAsync;
			var addedName = addedStorey.Name;
			Assert.AreEqual(name, addedName);

			//Delete the storey.
			var deleteStorey = new DeleteStorey(context);
			Task removeStoreyAsync = deleteStorey.RemoveStoreyAsync(addedStorey);
			await removeStoreyAsync;

			//Checking wheter the storey has been deleted:
			getLastStoreyAsync = getLastOrList.GetLastStoreyAsync();
			var listAfter = await getLastStoreyAsync;

			//Name collection after deleting
			var nameListAfter = storeyListBefore.Select(x => x.Name).ToList() as ICollection;

			//Name collection before adding and deleting vs list after
			CollectionAssert.AreEquivalent(nameListBefore, nameListAfter);

		}
	}
}
