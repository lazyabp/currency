using Lazy.Abp.CurrencyKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.CurrencyKit
{
    public abstract class CurrencyKitController : AbpController
    {
        protected CurrencyKitController()
        {
            LocalizationResource = typeof(CurrencyKitResource);
        }
    }
}
