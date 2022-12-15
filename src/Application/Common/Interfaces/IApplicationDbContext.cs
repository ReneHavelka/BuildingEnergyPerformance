using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
		public DbSet<Storeys> Storeys { get; set; }
		public DbSet<Spaces> Spaces { get; set; }
		public DbSet<BuildingElements> BuildingElements { get; set; }
		public DbSet<Layers> Layers { get; set; }
		public DbSet<SpaceTemperatures> SpaceTemperatures { get; set; }
		public DbSet<ThermalResistances> ThermalResistances { get; set; }
		public DbSet<ThermalConductivities> ThermalConductivities { get; set; }

		public Task<int> SaveChangesAsync();
	}
}
