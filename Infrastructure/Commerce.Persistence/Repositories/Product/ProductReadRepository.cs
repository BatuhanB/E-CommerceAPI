using Commerce.Application.Repositories;
using Commerce.Domain.Entities;
using Commerce.Persistence.Contexts;

namespace Commerce.Persistence.Repositories;

public class ProductReadRepository : ReadRepository<Product>,IProductReadRepository
{
	public ProductReadRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}