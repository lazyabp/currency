using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit
{
    [DependsOn(
        typeof(CurrencyKitApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CurrencyKitHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "CurrencyKit";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CurrencyKitApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
