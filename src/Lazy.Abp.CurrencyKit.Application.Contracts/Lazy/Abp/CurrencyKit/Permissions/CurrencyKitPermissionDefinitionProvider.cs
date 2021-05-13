using Lazy.Abp.CurrencyKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.CurrencyKit.Permissions
{
    public class CurrencyKitPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CurrencyKitPermissions.GroupName, L("Permission:CurrencyKit"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CurrencyKitResource>(name);
        }
    }
}
