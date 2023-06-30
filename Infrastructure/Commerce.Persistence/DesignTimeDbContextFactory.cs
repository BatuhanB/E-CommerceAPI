using Commerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Commerce.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private readonly IConfiguration _configuration;

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder = new ();
            dbContextOptionsBuilder.UseNpgsql(_configuration.GetConnectionString("ECommerceDb"));
            return new (dbContextOptionsBuilder.Options);
        }
    }
}
