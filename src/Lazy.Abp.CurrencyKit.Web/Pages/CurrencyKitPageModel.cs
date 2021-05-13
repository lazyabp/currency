using Lazy.Abp.CurrencyKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Lazy.Abp.CurrencyKit.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CurrencyKitPageModel : AbpPageModel
    {
        protected CurrencyKitPageModel()
        {
            LocalizationResourceType = typeof(CurrencyKitResource);
            ObjectMapperContext = typeof(CurrencyKitWebModule);
        }
    }
}