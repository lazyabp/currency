using Lazy.Abp.CurrencyKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Lazy.Abp.CurrencyKit.Pages
{
    public abstract class CurrencyKitPageModel : AbpPageModel
    {
        protected CurrencyKitPageModel()
        {
            LocalizationResourceType = typeof(CurrencyKitResource);
        }
    }
}