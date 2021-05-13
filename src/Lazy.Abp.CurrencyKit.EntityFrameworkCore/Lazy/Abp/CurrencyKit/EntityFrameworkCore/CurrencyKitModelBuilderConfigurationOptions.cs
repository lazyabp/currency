using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.CurrencyKit.EntityFrameworkCore
{
    public class CurrencyKitModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public CurrencyKitModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}