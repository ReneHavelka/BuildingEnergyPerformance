using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands
{
	[TestClass]
	public class EditStoreyTests
	{
		int id;
		public TryOutName tryOutName = new();
		ApplicationDbContext context = new();

		public EditStoreyTests()
		{
			//The id is gotten from the first record.
			id = context.Storeys.OrderBy(x => x.Id).FirstOrDefault().Id;
		}

		//The name of the storey should not be null.
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public async Task NameShouldNotBeNull()
		{
			await tryOutName.TryName(null, id);
		}

		//The name must consist of 4 characters at least.
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public async Task MinimalNameLength()
		{
			await tryOutName.TryName("Abc", id);
		}

		//The name must beginn with a letter.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task NameFirstCharacter()
		{
			await tryOutName.TryName("1bcd", id);
		}

		//The name must beginn with a capital letter.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task NameFirstUpperCharacter()
		{
			await tryOutName.TryName("abcd", id);
		}

		//The name must consist of the maximum of 20 characters.
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public async Task MaximalNameLength()
		{
			await tryOutName.TryName("A23456789012345678901", id);
		}

		//The name must be distinct from the others.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task DistinctName()
		{
			var name = context.Storeys.OrderBy(x => x.Id).LastOrDefault().Name;
			await tryOutName.TryName(name, id);
		}


	}
}
