using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyPerformanceTests.Common
{
	public class TestDbContext : DbContext
	{
		public virtual DbSet<Storey> Storeys { get; set; }
		public virtual DbSet<Space> Spaces { get; set; }
		public virtual DbSet<BuildingElement> BuildingElements { get; set; }
		public virtual DbSet<Layer> Layers { get; set; }
		public virtual DbSet<SpaceTemperature> SpaceTemperatures { get; set; }
		public virtual DbSet<ThermalResistance> ThermalResistances { get; set; }
		public virtual DbSet<ThermalConductivity> ThermalConductivities { get; set; }
	}
}
