using Commerce.Application.Repositories;
using Commerce.Domain.Entities;
using Commerce.Persistence.Contexts;

namespace Commerce.Persistence.Repositories;

public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
{
	// ReadRepository'den tum methodlara customer nesnesi icin erisiyoruz
	// Fakat ICustomerReadRepository interface'ini implemente etmemizin nedeni DI nesnesi olarak cagirmak icin
	public CustomerReadRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}