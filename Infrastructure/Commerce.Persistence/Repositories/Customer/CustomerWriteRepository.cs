using Commerce.Application.Repositories;
using Commerce.Domain.Entities;
using Commerce.Persistence.Contexts;

namespace Commerce.Persistence.Repositories;

public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
{
	public CustomerWriteRepository(AppDbContext context) : base(context)
	{
	}
}