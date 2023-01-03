using Application.Common.Interfaces;
using AutoMapper;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Services;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.CommonServices;
using Infrastructure.Persistance;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands
{




	[TestClass]
	public class EditStoreyTests
	{
		EditTryOutName tryOutName;
		IApplicationDbContext _context;
		IMapper _mapper;
		GetLastOrList getLastOrList;

		public EditStoreyTests()
		{
			var getContexMapper = new GetContexMapper();
			_context = getContexMapper.Context;
			_mapper = getContexMapper.Mapper;
			tryOutName = new EditTryOutName(_context, _mapper);
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

		//The name must be distinct from the others.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task DistinctName()
		{
			var name = _context.Storeys.OrderBy(x => x.Id).FirstOrDefault().Name;
			await tryOutName.TryName(name);
		}

		//Regular editing
		[TestMethod]
		public async Task RegularEditing()
		{
			string name = "Abcde";
			await tryOutName.TryName(name);
			var originalName = tryOutName.OriginalName;

			//Last record in storey database
			var modifiedStorey = await getLastOrList.GetLastStorey();
			//Modified storey name
			var modifiedName = modifiedStorey.Name;
			Assert.AreEqual(name, modifiedName);

			//Finally modify the name to the original one.
			modifiedStorey.Name = originalName;
			var _context = new ApplicationDbContext();
			tryOutName = new EditTryOutName(_context, _mapper);
			await tryOutName.TryName(originalName);
		}
	}
}
