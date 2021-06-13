using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lazy.Abp.CurrencyKit.EntityFrameworkCore
{
    public class CurrencyKitHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CurrencyKitHttpApiHostMigrationsDbContext>
    {
        public CurrencyKitHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CurrencyKitHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("CurrencyKit"));

            return new CurrencyKitHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
