using Microsoft.Extensions.DependencyInjection;
using Lazy.Abp.CurrencyKit.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.CurrencyKit.Blazor
{
    [DependsOn(
        typeof(CurrencyKitApplicationContractsModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAutoMapperModule)
        )]
    public class CurrencyKitBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<CurrencyKitBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<CurrencyKitBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new CurrencyKitMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(CurrencyKitBlazorModule).Assembly);
            });
        }
    }
}