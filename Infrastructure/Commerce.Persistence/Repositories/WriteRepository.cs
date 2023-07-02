using Commerce.Application.Repositories;
using Commerce.Domain.Entities.Common;
using Commerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
{
	private readonly AppDbContext _context;

	public WriteRepository(AppDbContext context)
	{
		_context = context;
	}

	public DbSet<T> Table => _context.Set<T>();
	public async Task<bool> AddAsync(T entity)
	{
		var result = await Table.AddAsync(entity);
		return result.State == EntityState.Added;
	}

	public async Task<bool> AddRangeAsync(List<T> entity)
	{
		await Table.AddRangeAsync(entity);
		return true;
	}

	public bool Update(T entity)
	{
		var result = Table.Update(entity);
		return result.State == EntityState.Modified;
	}

	public bool Remove(T entity)
	{
		var result = Table.Remove(entity);
		return result.State == EntityState.Deleted;
	}

	public bool RemoveRange(List<T> entity)
	{
		Table.RemoveRange(entity);
		return true;
	}

	public async Task<bool> Remove(string id)
	{
		var result = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

		return Remove(result);
	}

	public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}