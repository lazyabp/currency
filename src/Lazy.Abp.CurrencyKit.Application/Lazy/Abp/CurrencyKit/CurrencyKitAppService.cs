using Lazy.Abp.CurrencyKit.Localization;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CurrencyKit
{
    public abstract class CurrencyKitAppService : ApplicationService
    {
        protected CurrencyKitAppService()
        {
            LocalizationResource = typeof(CurrencyKitResource);
            ObjectMapperContext = typeof(CurrencyKitApplicationModule);
        }
    }
}
