using System.Linq.Expressions;
using Commerce.Domain.Entities.Common;

namespace Commerce.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
	Task<T> GetSingle(Expression<Func<T, bool>> predicate);
	Task<T> GetById(string id);
	IQueryable<T> GetAll();
	IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);

}