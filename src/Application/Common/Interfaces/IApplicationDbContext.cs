using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Storey> Storeys { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<BuildingElement> BuildingElements { get; set; }
        public DbSet<Layer> Layers { get; set; }
        public DbSet<SpaceTemperature> SpaceTemperatures { get; set; }
        public DbSet<ThermalResistance> ThermalResistances { get; set; }
        public DbSet<ThermalConductivity> ThermalConductivities { get; set; }

        public Task<int> SaveChangesAsync();

    }
}
