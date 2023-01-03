using Application.Common.Interfaces;
using Application.StoreysCQR.Commands;
using AutoMapper;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Services;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.CommonServices;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands
{
	[TestClass]
	public class CreateStoreyTests
	{
		CreateTryOutName tryOutName;
		IApplicationDbContext _context;
		GetLastOrList getLastOrList;

		public CreateStoreyTests()
		{
			var getContexMapper = new GetContexMapper();
			_context = getContexMapper.Context;
			IMapper mapper = getContexMapper.Mapper;
			tryOutName = new CreateTryOutName(_context, mapper);
			getLastOrList = new GetLastOrList();
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
			var lastStorey = await getLastOrList.GetLastStorey();

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
			var addedStorey = await getLastOrList.GetLastStorey();
			//Added storey name
			var addedName = addedStorey.Name;
			Assert.AreEqual(name, addedName);

			//Finally delete the added item.
			var deleteStorey = new DeleteStorey(_context);
			await deleteStorey.RemoveStoreyAsync	(addedStorey);
		}
	}
}
