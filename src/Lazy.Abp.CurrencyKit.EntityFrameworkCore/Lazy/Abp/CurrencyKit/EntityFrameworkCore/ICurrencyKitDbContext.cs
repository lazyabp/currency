using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Lazy.Abp.CurrencyKit.Currencies;

namespace Lazy.Abp.CurrencyKit.EntityFrameworkCore
{
    [ConnectionStringName(CurrencyKitDbProperties.ConnectionStringName)]
    public interface ICurrencyKitDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Currency> Currencies { get; set; }
    }
}
