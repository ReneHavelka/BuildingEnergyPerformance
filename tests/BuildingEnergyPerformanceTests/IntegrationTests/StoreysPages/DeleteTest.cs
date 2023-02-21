using Application.Common.Models;
using BuildingEnergyPerformanceTests.IntegrationTests.StoreyPages;
using Domain.Entities;
using Moq;
using WebUI.Pages.StoreyPages;

namespace BuildingEnergyPerformanceTests.IntegrationTests.StoreysPages
{
	[TestClass]
	public class DeleteTest
	{
		[TestMethod]
		public async Task DeleteItem()
		{
			CreateEditTests createEditTests = new();
			var (mockSet, mockContext, mapper) = await createEditTests.ContextMapper();

			///Delete
			var delete = new DeleteModel(mockContext.Object, mapper);
			delete.StoreyDto = new() { };
			Storey storey = mapper.Map<Storey>(delete.StoreyDto);

			await delete.OnPostAsync();

			mockSet.Verify(m => m.Remove(It.IsAny<Storey>()), Times.Once());
			mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());
		}
	}
}
