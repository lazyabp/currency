using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.CurrencyKit.EntityFrameworkCore
{
    public class CurrencyKitHttpApiHostMigrationsDbContext : AbpDbContext<CurrencyKitHttpApiHostMigrationsDbContext>
    {
        public CurrencyKitHttpApiHostMigrationsDbContext(DbContextOptions<CurrencyKitHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureCurrencyKit();
        }
    }
}
