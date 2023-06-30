using Commerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Application.Repositories;

public interface IRepository<T> where T : BaseEntity, new()
{
	DbSet<T> Table { get; }
}