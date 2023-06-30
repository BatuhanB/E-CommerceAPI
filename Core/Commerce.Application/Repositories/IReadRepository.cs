using System.Linq.Expressions;
using Commerce.Domain.Entities.Common;

namespace Commerce.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
{
	Task<T> GetSingle(Expression<Func<T, bool>> predicate, bool tracking = true);
	Task<T> GetByIdAsync(string id, bool tracking = true);
	IQueryable<T> GetAll(bool tracking = true);
	IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);

}