using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit
{
    [DependsOn(
        typeof(CurrencyKitHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CurrencyKitConsoleApiClientModule : AbpModule
    {
        
    }
}
