using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands
{
	[TestClass]
	public class CreateStoreyTests
	{
		public TryOutName tryOutName = new();

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
			var context = new ApplicationDbContext();
			var name = context.Storeys.OrderBy(x => x.Id).LastOrDefault().Name;
			await tryOutName.TryName(name);
		}
	}
}
