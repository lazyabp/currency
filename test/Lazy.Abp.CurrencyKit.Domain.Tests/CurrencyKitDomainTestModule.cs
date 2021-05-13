using Lazy.Abp.CurrencyKit.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(CurrencyKitEntityFrameworkCoreTestModule)
        )]
    public class CurrencyKitDomainTestModule : AbpModule
    {
        
    }
}
