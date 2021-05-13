using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Lazy.Abp.CurrencyKit.Currencies;

namespace Lazy.Abp.CurrencyKit.EntityFrameworkCore
{
    [ConnectionStringName(CurrencyKitDbProperties.ConnectionStringName)]
    public class CurrencyKitDbContext : AbpDbContext<CurrencyKitDbContext>, ICurrencyKitDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Currency> Currencies { get; set; }

        public CurrencyKitDbContext(DbContextOptions<CurrencyKitDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureCurrencyKit();
        }
    }
}
