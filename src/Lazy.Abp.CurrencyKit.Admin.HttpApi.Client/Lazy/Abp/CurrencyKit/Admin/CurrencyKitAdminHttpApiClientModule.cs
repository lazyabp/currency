using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit.Admin
{
    [DependsOn(
        typeof(CurrencyKitAdminApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CurrencyKitAdminHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(CurrencyKitAdminApplicationContractsModule).Assembly,
                CurrencyKitAdminRemoteServiceConsts.RemoteServiceName);
        }
    }
}
