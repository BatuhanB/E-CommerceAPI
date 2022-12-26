using Commerce.Application.Abstractions;
using Commerce.Persistence.Concretes;
using Commerce.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Commerce.Persistence.Extensions
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddPersistencesServices(this IServiceCollection services, IConfiguration configuration)
		{
			//services.AddScoped<IProductService, ProductService>();
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseNpgsql(configuration.GetConnectionString("ECommerceDb"));
			});

			return services;
		}
	}
}
