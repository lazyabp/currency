using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit.Blazor.WebAssembly
{
    [DependsOn(
        typeof(CurrencyKitBlazorModule),
        typeof(CurrencyKitHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class CurrencyKitBlazorWebAssemblyModule : AbpModule
    {
        
    }
}