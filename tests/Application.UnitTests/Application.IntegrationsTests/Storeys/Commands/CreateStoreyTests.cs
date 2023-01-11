using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Services;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.CommonServices;
using FluentValidation;
using System.Diagnostics;

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

		//The name must be distinct from the others. Take out the last name and try to add.
		[TestMethod]
		[ExpectedException(typeof(ValidationException))]
		public async Task DistinctName()
		{
			//Last record in storey database
			Task<StoreysDto> lastStoreyTask = getLastOrList.GetLastStoreyAsync();
			var lastStorey = await lastStoreyTask;

			var name = lastStorey.Name;
			Task distinctName = tryOutName.TryNameAsync(name);
			await distinctName;
		}

		//Regular adding.
		[TestMethod]
		public async Task RegularAdding()
		{
			string name = "Abcde";
			Task tryNameTask = tryOutName.TryNameAsync(name);
			await tryNameTask;

			//Last record in storey database
			var addedStoreyTask = getLastOrList.GetLastStoreyAsync();
			var addedStorey = await addedStoreyTask;
			//Added storey name
			var addedName = addedStorey.Name;
			Assert.AreEqual(name, addedName);

			//Finally delete the added item.
			
			
			var deleteStorey = new DeleteStorey(_context);
			Task deleteAddedStorey = deleteStorey.RemoveStoreyAsync(addedStorey);
			await deleteAddedStorey;
		}
	}
}
