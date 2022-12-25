using Commerce.Application.Abstractions;
using Commerce.Domain.Entities;

namespace Commerce.Persistence.Concretes
{
	public class ProductService : IProductService
	{
		public List<Product> GetProducts()
		=> new() 
		{
			new() { Id = Guid.NewGuid() , Name = "Product1" , Price= 120, Stock= 12},	
			new() { Id = Guid.NewGuid() , Name = "Product2" , Price= 1212, Stock= 12},	
			new() { Id = Guid.NewGuid() , Name = "Product3" , Price= 1253, Stock= 12},	
			new() { Id = Guid.NewGuid() , Name = "Product4" , Price= 1506, Stock= 12},	
		};
	}
}
