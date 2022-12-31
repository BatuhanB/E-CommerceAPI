using Commerce.Application.Repositories;
using Commerce.Domain.Entities;
using Commerce.Persistence.Contexts;

namespace Commerce.Persistence.Repositories;

public class OrderWriteRepository : WriteRepository<Order>,IOrderWriteRepository
{
	public OrderWriteRepository(AppDbContext context) : base(context)
	{
	}
}