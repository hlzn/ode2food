using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace odetoofd.data
{
    public class OdeToFoodFactory : IDesignTimeDbContextFactory<OdeToFoodDbContext>
    {
        public OdeToFoodDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        
            var dbContextBuilder = new DbContextOptionsBuilder<OdeToFoodDbContext>();
        
            var connectionString = configuration
                        .GetConnectionString("OdeToFood");
        
            dbContextBuilder.UseSqlServer(connectionString);
        
            return new OdeToFoodDbContext(dbContextBuilder.Options);
        }
    }
}