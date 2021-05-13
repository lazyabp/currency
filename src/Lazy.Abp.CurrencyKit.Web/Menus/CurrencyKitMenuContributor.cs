using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.CurrencyKit.Web.Menus
{
    public class CurrencyKitMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(CurrencyKitMenus.Prefix, displayName: "CurrencyKit", "~/CurrencyKit", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}