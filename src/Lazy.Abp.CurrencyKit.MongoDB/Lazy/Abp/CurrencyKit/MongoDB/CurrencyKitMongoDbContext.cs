using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.CurrencyKit.MongoDB
{
    [ConnectionStringName(CurrencyKitDbProperties.ConnectionStringName)]
    public class CurrencyKitMongoDbContext : AbpMongoDbContext, ICurrencyKitMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureCurrencyKit();
        }
    }
}