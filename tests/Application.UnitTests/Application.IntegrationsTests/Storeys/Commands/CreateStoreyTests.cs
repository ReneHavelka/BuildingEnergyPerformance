using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using Application.StoreysCQR.Queries;
using AutoMapper;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Common;
using Infrastructure.Persistance;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands
{
	[TestClass]
	public class CreateStoreyTests
	{
		public CreateTryOutName tryOutName = new();
		IApplicationDbContext context;
		IMapper mapper;

		public CreateStoreyTests()
		{
			var getContexMapper = new GetContexMapper();
			context = getContexMapper.Context;
			mapper = getContexMapper.Mapper;
		}

		//The name of the storey should not be null.
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public async Task NameShouldNotBeNull()
		{
			await tryOutName.TryName(null);
		}

		//The name must consist of 4 characters at least.
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public async Task MinimalNameLength()
		{
			await tryOutName.TryName("Abc");
		}

		//The name must beginn with a letter.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task NameFirstCharacter()
		{
			await tryOutName.TryName("1bcd");
		}

		//The name must beginn with a capital letter.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task NameFirstUpperCharacter()
		{
			await tryOutName.TryName("abcd");
		}

		//The name must consist of the maximum of 20 characters.
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public async Task MaximalNameLength()
		{
			await tryOutName.TryName("A23456789012345678901");
		}

		//The name must be distinct from the others. Take out the last name and try to add.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task DistinctName()
		{
			//Last record in storey database
			var getLastStoreyListAndLast = new GetStoreyListAndLast();
			var lastStorey = await getLastStoreyListAndLast.GetLastStorey();

			var name = lastStorey.Name;
			await tryOutName.TryName(name);
		}

		//Regular adding.
		[TestMethod]
		public async Task RegularAdding()
		{
			string name = "Abcde";
			await tryOutName.TryName(name);

			//Last record in storey database
			var getLastStorey = new Common.GetStoreyListAndLast();
			var addedStorey = await getLastStorey.GetLastStorey();
			//Added storey name
			var addedName = addedStorey.Name;
			Assert.AreEqual(name, addedName);

			var deleteStorey = new DeleteStorey(context);
			await deleteStorey.RemoveStorey(addedStorey);
		}
	}
}
