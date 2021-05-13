using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Lazy.Abp.CurrencyKit
{
    [DependsOn(
        typeof(CurrencyKitDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class CurrencyKitApplicationContractsModule : AbpModule
    {

    }
}
