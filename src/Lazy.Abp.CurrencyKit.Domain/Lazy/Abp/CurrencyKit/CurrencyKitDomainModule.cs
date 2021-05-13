using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(CurrencyKitDomainSharedModule)
    )]
    public class CurrencyKitDomainModule : AbpModule
    {

    }
}
