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
		public DbSet<Layers> Layers { get; set; }
		public DbSet<SpaceTemperatures> SpaceTemperatures { get; set; }
		public DbSet<ThermalResistances> ThermalResistances { get; set; }
		public DbSet<ThermalConductivities> ThermalConductivities { get; set; }

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
