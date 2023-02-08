using Application.Common.Interfaces;
using AutoMapper;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Services;
using BuildingEnergyPerformanceTests.CommonServices;
using FluentValidation;
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
		[ExpectedException(typeof(ValidationException))]
		public async Task NameShouldNotBeNull()
		{
			Task nameShouldNotBeNull = tryOutName.TryNameAsync(null);
			await nameShouldNotBeNull;
		}

		//The name must consist of 4 characters at least.
		[TestMethod]
		[ExpectedException(typeof(ValidationException))]
		public async Task MinimalNameLength()
		{
			Task minimalNameLength = tryOutName.TryNameAsync("Abc");
			await minimalNameLength;
		}

		//The name must beginn with a letter.
		[TestMethod]
		[ExpectedException(typeof(ValidationException))]
		public async Task NameFirstCharacter()
		{
			Task nameFirstCharacter = tryOutName.TryNameAsync("1bcd");
			await nameFirstCharacter;
		}

		//The name must beginn with a capital letter.
		[TestMethod]
		[ExpectedException(typeof(ValidationException))]
		public async Task NameFirstUpperCharacter()
		{
			Task nameFirstUpperCharacter = tryOutName.TryNameAsync("abcd");
			await nameFirstUpperCharacter;
		}

		//The name must consist of the maximum of 20 characters.
		[TestMethod]
		[ExpectedException(typeof(ValidationException))]
		public async Task MaximalNameLength()
		{
			Task maximalNameLength = tryOutName.TryNameAsync("A23456789012345678901");
			await maximalNameLength;
		}

		//The name must be distinct from the others.
		[TestMethod]
		[ExpectedException(typeof(ValidationException))]
		public async Task DistinctName()
		{
			var name = _context.Storeys.OrderBy(x => x.Id).FirstOrDefault().Name;
			var tryNameAsync = tryOutName.TryNameAsync(name);
			await tryNameAsync;
		}

		//Regular editing
		[TestMethod]
		public async Task RegularEditing()
		{
			string name = "Abcde";
			var tryNameAsync = tryOutName.TryNameAsync(name);
			await tryNameAsync;
			var originalName = tryOutName.OriginalName;

			//Last record in storey database
			var getLastStoreyAsync = getLastOrList.GetLastStoreyAsync();
			var modifiedStorey = await getLastStoreyAsync;
			//Modified storey name
			var modifiedName = modifiedStorey.Name;
			Assert.AreEqual(name, modifiedName);

			//Finally modify the name to the original one.
			var _context = new ApplicationDbContext();
			tryOutName = new EditTryOutName(_context, _mapper);
			await tryOutName.TryNameAsync(originalName);
		}
	}
}
