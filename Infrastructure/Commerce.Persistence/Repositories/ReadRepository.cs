using System.Linq.Expressions;
using Commerce.Application.Repositories;
using Commerce.Domain.Entities.Common;
using Commerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
	private readonly AppDbContext _dbContext;
	public ReadRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public DbSet<T> Table => _dbContext.Set<T>();

	public async Task<T> GetSingle(Expression<Func<T, bool>> predicate) => await Table.FirstOrDefaultAsync(predicate);

	public async Task<T> GetById(string id) => await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

	public IQueryable<T> GetAll() => Table;

	public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate) => Table.Where(predicate);
}