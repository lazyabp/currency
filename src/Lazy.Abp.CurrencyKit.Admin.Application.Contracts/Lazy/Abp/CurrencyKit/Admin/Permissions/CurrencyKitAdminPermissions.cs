using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Reflection;

namespace Lazy.Abp.CurrencyKit.Admin.Permissions
{
    public class CurrencyKitAdminPermissions
    {
        public const string GroupName = "CurrencyKit.Admin";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CurrencyKitAdminPermissions));
        }

        public class Currency
        {
            public const string Default = GroupName + ".Currency";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
