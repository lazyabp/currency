namespace Lazy.Abp.CurrencyKit
{
    public static class CurrencyKitDbProperties
    {
        public static string DbTablePrefix { get; set; } = "CurrencyKit";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "CurrencyKit";
    }
}
