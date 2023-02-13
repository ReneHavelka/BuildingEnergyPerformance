using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyPerformanceTests.Common
{
	public class TestDbContext : DbContext
	{
		public virtual DbSet<Storeys> Storeys { get; set; }
		public virtual DbSet<Spaces> Spaces { get; set; }
		public virtual DbSet<BuildingElements> BuildingElements { get; set; }
		public virtual DbSet<Layers> Layers { get; set; }
		public virtual DbSet<SpaceTemperatures> SpaceTemperatures { get; set; }
		public virtual DbSet<ThermalResistances> ThermalResistances { get; set; }
		public virtual DbSet<ThermalConductivities> ThermalConductivities { get; set; }
	}
}
