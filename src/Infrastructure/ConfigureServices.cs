using Application.Common.Interfaces;
using Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			//services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddDbContext<ApplicationDbContext>();
			services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

			return services;
		}
	}
}
