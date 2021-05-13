using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.CurrencyKit.MongoDB
{
    public class CurrencyKitMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public CurrencyKitMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}