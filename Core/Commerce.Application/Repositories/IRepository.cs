using Commerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
	DbSet<T> Table { get; }
}