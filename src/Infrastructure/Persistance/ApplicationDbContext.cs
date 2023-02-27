using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public virtual DbSet<Storey> Storeys { get; set; }
        public virtual DbSet<Space> Spaces { get; set; }
        public virtual DbSet<BuildingElement> BuildingElements { get; set; }
        public virtual DbSet<Layer> Layers { get; set; }
        public virtual DbSet<SpaceTemperature> SpaceTemperatures { get; set; }
        public virtual DbSet<ThermalResistance> ThermalResistances { get; set; }
        public virtual DbSet<ThermalConductivity> ThermalConductivities { get; set; }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=BuildingEnergyPeformance;Trusted_Connection=True");
        }
    }
}
