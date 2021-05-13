using Lazy.Abp.CurrencyKit.Currencies;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit.EntityFrameworkCore
{
    [DependsOn(
        typeof(CurrencyKitDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class CurrencyKitEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CurrencyKitDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Currency, CurrencyRepository>();
            });
        }
    }
}
