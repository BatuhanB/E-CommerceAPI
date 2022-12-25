using Commerce.Domain.Entities;

namespace Commerce.Application.Abstractions
{
	public interface IProductService
	{
		List<Product> GetProducts();
	}
}
