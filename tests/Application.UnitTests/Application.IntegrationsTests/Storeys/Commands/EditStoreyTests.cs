using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using Application.StoreysCQR.Queries;
using AutoMapper;
using BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Common;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands
{
 //   [TestClass]
	//public class EditStoreyTests
	//{
	//	internal EditTryOutName tryOutName = new();
	//	IApplicationDbContext context;
	//	IMapper mapper;


	//	public EditStoreyTests()
	//	{
	//		var getContexMapper = new GetContexMapper();
	//		context = getContexMapper.Context;
	//		mapper = getContexMapper.Mapper;
	//	}

	//	//The name of the storey should not be null.
	//	[TestMethod]
	//	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	//	public async Task NameShouldNotBeNull()
	//	{
	//		await tryOutName.TryName(null);
	//	}

	//	//The name must consist of 4 characters at least.
	//	[TestMethod]
	//	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	//	public async Task MinimalNameLength()
	//	{
	//		await tryOutName.TryName("Abc");
	//	}

	//	//The name must beginn with a letter.
	//	[TestMethod]
	//	[ExpectedException(typeof(ArgumentException))]
	//	public async Task NameFirstCharacter()
	//	{
	//		await tryOutName.TryName("1bcd");
	//	}

	//	//The name must beginn with a capital letter.
	//	[TestMethod]
	//	[ExpectedException(typeof(ArgumentException))]
	//	public async Task NameFirstUpperCharacter()
	//	{
	//		await tryOutName.TryName("abcd");
	//	}

	//	//The name must consist of the maximum of 20 characters.
	//	[TestMethod]
	//	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	//	public async Task MaximalNameLength()
	//	{
	//		await tryOutName.TryName("A23456789012345678901");
	//	}

	//	//The name must be distinct from the others.
	//	[TestMethod]
	//	[ExpectedException(typeof(ArgumentException))]
	//	public async Task DistinctName()
	//	{
	//		var name = context.Storeys.OrderBy(x => x.Id).LastOrDefault().Name;
	//		await tryOutName.TryName(name);
	//	}

	//	//Regular editing
	//	[TestMethod]
	//	public async Task RegularEditing()
	//	{
	//		var originalName = tryOutName.OriginalName; 

	//		string name = "Abcde";
	//		await tryOutName.TryName(name);
	//		//var editedStorey = context.Storeys.OrderBy(x => x.Id).LastOrDefault();
	//		//Assert.AreEqual(name, editedStorey.Name);

	//		//var getStorey = new GetStorey(context, mapper);
	//		//var addedStoreyDto = getStorey.GetStoreyDto(editedStorey.Id);

	//		//await tryOutName.TryName(originalName);
	//	}
	//}
}
