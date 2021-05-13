using System;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit.Admin
{
    [DependsOn(
        typeof(CurrencyKitAdminApplicationModule)
        )]
    public class CurrencyKitAdminApplicationHostModule : AbpModule
    {
    }
}
