using Application.StoreysCQR.Commands;
using Application.StoreysCQR.Queries;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Services;
using Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			//Storey list before adding and deleting
			var listBefore = await getLastOrList.GetStoreyList();

			//Add a new storey.
			string name = "DeleteTest";
			var createTryOutName = new CreateTryOutName(context, mapper);
			await createTryOutName.TryName(name);

			//Checking whether the new name has been added.
			//Last record in storey database
			var addedStorey = await getLastOrList.GetLastStorey();
			var addedName = addedStorey.Name;
			Assert.AreEqual(name, addedName);

			//Delete the storey.
			var deleteStorey = new DeleteStorey(context);
			await deleteStorey.RemoveStorey(addedStorey);

			//Checking wheter the storey has been deleted:
			var listAfter = await getLastOrList.GetStoreyList();
			//Checking the size of both lists
			Assert.AreEqual(listAfter.Count, listBefore.Count);
			//Storey list before adding and deleting vs list after
			for (int i = 0; i < listAfter.Count; i++)
			{
				Assert.AreEqual(listBefore[i].Name, listAfter[i].Name);
			}
			
		}
	}
}
