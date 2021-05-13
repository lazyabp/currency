using Localization.Resources.AbpUi;
using Lazy.Abp.CurrencyKit.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Lazy.Abp.CurrencyKit
{
    [DependsOn(
        typeof(CurrencyKitApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class CurrencyKitHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CurrencyKitHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<CurrencyKitResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
