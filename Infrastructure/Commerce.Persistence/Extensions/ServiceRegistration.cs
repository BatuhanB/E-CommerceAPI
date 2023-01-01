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
			services.AddDbContext<AppDbContext>(options =>
					options.UseNpgsql(configuration.GetConnectionString("ECommerceDb")));

			services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
			services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
			services.AddScoped<IOrderReadRepository, OrderReadRepository>();
			services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
			services.AddScoped<IProductReadRepository, ProductReadRepository>();
			services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

			return services;
		}
	}
}
