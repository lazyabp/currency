using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(CurrencyKitBlazorModule)
        )]
    public class CurrencyKitBlazorServerModule : AbpModule
    {
        
    }
}