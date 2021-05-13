using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.CurrencyKit
{
    [Dependency(ReplaceServices = true)]
    public class CurrencyKitBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CurrencyKit";
    }
}
