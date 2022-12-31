using Commerce.Application.Repositories;
using Commerce.Domain.Entities;
using Commerce.Persistence.Contexts;

namespace Commerce.Persistence.Repositories;

public class OrderReadRepository : ReadRepository<Order>,IOrderReadRepository
{
	public OrderReadRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}