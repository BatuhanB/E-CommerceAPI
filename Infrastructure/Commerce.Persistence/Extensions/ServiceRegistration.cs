using Commerce.Application.Repositories;
using Commerce.Persistence.Contexts;
using Commerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commerce.Persistence.Extensions
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			//services.AddScoped<IProductService, ProductService>();
			services.AddDbContext<AppDbContext>(options =>
					options.UseNpgsql(configuration.GetConnectionString("ECommerceDb")),ServiceLifetime.Singleton);

			services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
			services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
			services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
			services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
			services.AddSingleton<IProductReadRepository, ProductReadRepository>();
			services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();

			return services;
		}
	}
}
