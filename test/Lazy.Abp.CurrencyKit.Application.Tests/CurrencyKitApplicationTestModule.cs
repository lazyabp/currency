using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit
{
    [DependsOn(
        typeof(CurrencyKitApplicationModule),
        typeof(CurrencyKitDomainTestModule)
        )]
    public class CurrencyKitApplicationTestModule : AbpModule
    {

    }
}
