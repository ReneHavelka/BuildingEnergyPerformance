using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;

namespace BuildingEnergyPerformanceTests.Common
{
    internal class GetContexMapper
    {
        internal IApplicationDbContext Context { get; }

        internal IMapper Mapper { get; }

        internal GetContexMapper()
        {
            Context = new ApplicationDbContext();

            var mappingProfile = new MappingProfile();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            Mapper = new Mapper(config);
        }
    }
}
