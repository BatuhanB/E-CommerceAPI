using Commerce.Domain.Entities.Common;

namespace Commerce.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
{
	Task<bool> AddAsync(T entity);
	Task<bool> AddRangeAsync(List<T> entity);
	bool Update(T entity);
	bool Remove(T entity);
	bool RemoveRange(List<T> entity);
	Task<bool> Remove(string id);
	Task<int> SaveChanges();
}