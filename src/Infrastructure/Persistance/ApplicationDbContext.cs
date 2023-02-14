using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public DbSet<Storey> Storeys { get; set; }
		public DbSet<Space> Spaces { get; set; }
		public DbSet<BuildingElement> BuildingElements { get; set; }
		public DbSet<Layer> Layers { get; set; }
		public DbSet<SpaceTemperature> SpaceTemperatures { get; set; }
		public DbSet<ThermalResistance> ThermalResistances { get; set; }
		public DbSet<ThermalConductivity> ThermalConductivities { get; set; }

		public async Task<int> SaveChangesAsync()
		{
			return await base.SaveChangesAsync();
		}

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
