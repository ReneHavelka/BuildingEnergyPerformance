using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;

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

		//The name of the storey should not be null or empty.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task NameShouldNotBeNullOrEmpty()
		{
			var storey = _context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			var idBefore = storey.Id;

			StoreysDto storeyDto = new();
			CreateStorey createStorey = new(_context, _mapper);
			storeyDto.Name = null;

			await createStorey.AddStorey(storeyDto);

			storey = _context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			Assert.IsTrue(storey.Id == idBefore);

			storeyDto.Name = String.Empty;

			await createStorey.AddStorey(storeyDto);

			//No data added
			storey = _context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			Assert.IsTrue(storey.Id == idBefore);
		}

		//The name of the storey must consist of 4 characters at least.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task MinimalNameLength()
		{
			var storey = _context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			var idBefore = storey.Id;

			StoreysDto storeyDto = new();
			CreateStorey createStorey = new(_context, _mapper);
			storeyDto.Name = "Abc";

			await createStorey.AddStorey(storeyDto);

			storey = _context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			Assert.IsTrue(storey.Id == idBefore);
		}

		//The name of the storey must beginn with a capital letter.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task NameFirstCharacter()
		{
			var storey = _context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			var idBefore = storey.Id;

			StoreysDto storeyDto = new();
			CreateStorey createStorey = new(_context, _mapper);
			storeyDto.Name = "abcd";

			await createStorey.AddStorey(storeyDto);

			storey = _context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			Assert.IsTrue(storey.Id == idBefore);

			storeyDto.Name = "1bcd";

			await createStorey.AddStorey(storeyDto);

			//No data added
			storey = _context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			Assert.IsTrue(storey.Id == idBefore);
		}

		//The name of the storey must consist of the maximum of 14 characters.
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task MaximalNameLength()
		{
			var storey = _context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			var idBefore = storey.Id;

			StoreysDto storeyDto = new();
			CreateStorey createStorey = new(_context, _mapper);
			storeyDto.Name = "A23456789ABCDEF";

			await createStorey.AddStorey(storeyDto);

			//No data added
			storey = _context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			Assert.IsTrue(storey.Id == idBefore);
		}
	}
}
