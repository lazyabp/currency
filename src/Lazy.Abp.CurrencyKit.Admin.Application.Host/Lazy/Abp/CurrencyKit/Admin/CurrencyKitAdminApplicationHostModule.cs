using Lazy.Abp.Core;
using Lazy.Abp.CurrencyKit.Admin.BackgroundWorkers;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit.Admin
{
    [DependsOn(
        typeof(CurrencyKitAdminApplicationModule),
        typeof(AbpBackgroundWorkersModule),
        typeof(LazyAbpCoreModule)
        )]
    public class CurrencyKitAdminApplicationHostModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.AddBackgroundWorker<ExchangeRateUpdateBackgroundWorker>();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
