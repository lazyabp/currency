using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.CurrencyKit.MongoDB
{
    [ConnectionStringName(CurrencyKitDbProperties.ConnectionStringName)]
    public interface ICurrencyKitMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
