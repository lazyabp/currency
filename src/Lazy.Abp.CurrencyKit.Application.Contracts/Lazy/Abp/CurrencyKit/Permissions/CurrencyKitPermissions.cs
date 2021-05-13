using Volo.Abp.Reflection;

namespace Lazy.Abp.CurrencyKit.Permissions
{
    public class CurrencyKitPermissions
    {
        public const string GroupName = "CurrencyKit";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CurrencyKitPermissions));
        }
    }
}
