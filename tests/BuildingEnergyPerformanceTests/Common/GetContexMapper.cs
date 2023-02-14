using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BuildingEnergyPerformanceTests.Common
{
	internal class GetContexMapper
	{
		internal Mock<IApplicationDbContext> MockContext { get; }

		internal IMapper Mapper { get; }

		internal GetContexMapper()
		{
			var mockSet = new Mock<DbSet<Storey>>();
			MockContext = new Mock<IApplicationDbContext>();
			MockContext.Setup(m => m.Storeys).Returns(mockSet.Object);

			var mappingProfile = new MappingProfile();
			var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
			Mapper = new Mapper(config);
		}
	}
}
