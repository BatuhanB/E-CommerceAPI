using Commerce.Application.Abstractions;
using Commerce.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace Commerce.Persistence.Extensions
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddPersistencesServices(this IServiceCollection services)
		{
			services.AddSingleton<IProductService,ProductService>();

			return services;
		}
	}
}
