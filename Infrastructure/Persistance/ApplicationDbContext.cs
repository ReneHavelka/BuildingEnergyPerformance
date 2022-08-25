using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Storeys> Storeys { get; set; }
        public DbSet<Spaces> Spaces { get; set; }
        public DbSet<BuildingElements> BuildingElements { get; set; }
        public DbSet<BuildingElementComponents> BuildingsElementComponents { get; set; }
        public DbSet<Layers> Layers { get; set; }
        public DbSet<SpaceTemperatures> SpaceTemperatures { get; set; }
        public DbSet<ThermalResistanceTable> ThermalResistanceTable { get; set; }
        public DbSet<ThermalConductivityTable> ThermalConductivityTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=BuildingEnergyPeformance;Trusted_Connection=True");
        }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{
        //}
    }
}
