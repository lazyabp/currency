using System.Threading.Tasks;
using Lazy.Abp.CurrencyKit.Localization;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.CurrencyKit.Blazor.Host
{
    public class CurrencyKitHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<CurrencyKitResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "CurrencyKit.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
