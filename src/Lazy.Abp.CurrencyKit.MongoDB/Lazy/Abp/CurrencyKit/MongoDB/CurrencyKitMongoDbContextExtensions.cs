using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.CurrencyKit.MongoDB
{
    public static class CurrencyKitMongoDbContextExtensions
    {
        public static void ConfigureCurrencyKit(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CurrencyKitMongoModelBuilderConfigurationOptions(
                CurrencyKitDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}