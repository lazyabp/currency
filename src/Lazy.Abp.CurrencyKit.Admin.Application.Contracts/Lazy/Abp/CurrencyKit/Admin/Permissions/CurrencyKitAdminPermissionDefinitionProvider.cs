using Lazy.Abp.CurrencyKit.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.CurrencyKit.Admin.Permissions
{
    public class CurrencyKitAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CurrencyKitAdminPermissions.GroupName, L("Permission:CurrencyKitAdmin"));

            var currencyPermission = myGroup.AddPermission(CurrencyKitAdminPermissions.Currency.Default, L("Permission:Currency"));
            currencyPermission.AddChild(CurrencyKitAdminPermissions.Currency.Create, L("Permission:Create"));
            currencyPermission.AddChild(CurrencyKitAdminPermissions.Currency.Update, L("Permission:Update"));
            currencyPermission.AddChild(CurrencyKitAdminPermissions.Currency.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CurrencyKitResource>(name);
        }
    }
}
