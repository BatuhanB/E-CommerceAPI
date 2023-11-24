using System.Linq.Expressions;
using Commerce.Application.Repositories;
using Commerce.Domain.Entities.Common;
using Commerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
	private readonly AppDbContext _dbContext;
	public ReadRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public DbSet<T> Table => _dbContext.Set<T>();

	public async Task<T> GetSingle(Expression<Func<T, bool>> predicate, bool tracking = true)
	{
		var query = Table.AsQueryable();
		if (!tracking)
			query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(predicate);
	}

	public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
	{
		var query = Table.AsQueryable();
		if (!tracking) query = query.AsNoTracking();
		return await query.FirstOrDefaultAsync(x => x.Id == id);
	}

	public IQueryable<T> GetAll(bool tracking = true)
	{
		var query = Table.AsQueryable();
		if (!tracking)
			query = query.AsNoTracking();
		return query;
	}

	public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
	{
		var query = Table.Where(predicate);
		if (!tracking)
			query = query.AsNoTracking();
		return query;
	}
}