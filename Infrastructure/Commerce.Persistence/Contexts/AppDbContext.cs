using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Persistence.Contexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{ }

	public DbSet<Product> Products { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Customer> Customers { get; set; }
}