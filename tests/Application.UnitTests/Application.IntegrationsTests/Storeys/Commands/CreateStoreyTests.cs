using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;
using System.Diagnostics;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands
{
	[TestClass]
	public class CreateStoreyTests
	{
		IApplicationDbContext _context;
		IMapper _mapper;
		public CreateStoreyTests()
		{
			_context = new ApplicationDbContext();

			var mappingProfile = new MappingProfile();
			var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
			_mapper = new Mapper(config);
		}

		public async Task TryName(string str)
		{
			StoreysDto storeyDto = new();
			CreateStorey createStorey = new(_context, _mapper);
			storeyDto.Name = str;

			try
			{
				await createStorey.AddStorey(storeyDto);
			}
			catch
			{
				throw new ArgumentException();
			}
		}

		//The name of the storey should not be null.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task NameShouldNotBeNull()
		{
			await TryName(null);
		}

		//The name must consist of 4 characters at least.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task MinimalNameLength()
		{
			await TryName("Abc");
		}

		//The name must beginn with a letter.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task NameFirstCharacter()
		{
			await TryName("1bcd");
		}

		//The name must beginn with a capital letter.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task NameFirstUpperCharacter()
		{
			await TryName("abcd");
		}

		//The name must consist of the maximum of 20 characters.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task MaximalNameLength()
		{
			await TryName("A23456789012345678901");
		}

		//The name must be distinct from the others.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task DistinctName()
		{
			var name = _context.Storeys.OrderBy(x => x.Id).LastOrDefault().Name;
			await TryName(name);
		}
	}
}
