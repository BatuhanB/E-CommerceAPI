using Commerce.Domain.Entities;
using Commerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Persistence.Contexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{ }

	public DbSet<Product> Products { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Customer> Customers { get; set; }



	public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		// ChangeTracker =	Entityler uzerinde yapilan degisikliklerin ya da yeni eklenen verinin yakalanmasini saglayan propertydir. Update operasoynlarinda Track edilen verileri yakalayip elde etmemizi saglar.

		var datas = ChangeTracker.Entries<BaseEntity>();
		foreach (var entries in datas)
		{
			_ = entries.State switch
			{
				EntityState.Added => entries.Entity.CreateDate = DateTime.UtcNow,
				EntityState.Modified => entries.Entity.UpdatedDate = DateTime.UtcNow,
			};
			
		}
		return await base.SaveChangesAsync(cancellationToken);
	}
}