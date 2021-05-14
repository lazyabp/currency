using Lazy.Abp.Core;
using Lazy.Abp.CurrencyKit.Currencies;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Uow;

namespace Lazy.Abp.CurrencyKit.Admin.EventHandlers
{
    public class ExchangeRateUpdateEventHandelr : 
        IDistributedEventHandler<AutoUpdateAllExchangeRateEto>,
        IUnitOfWorkEnabled,
        ITransientDependency
    {
        private readonly ICurrencyRepository _reository;
        private readonly IExchangeRateApiService _exchangeRateApiService;

        public ExchangeRateUpdateEventHandelr(
            ICurrencyRepository reository,
            IExchangeRateApiService exchangeRateApiService
        )
        {
            _reository = reository;
            _exchangeRateApiService = exchangeRateApiService;
        }

        [UnitOfWork]
        public async Task HandleEventAsync(AutoUpdateAllExchangeRateEto eventData)
        {
            // 获取货币汇率并执行更新
            var exchangeRate = await _exchangeRateApiService.QueryAsync();
            var currencies = await _reository.GetAllListAsync();

            foreach (var currency in currencies)
            {
                if (exchangeRate.ContainsKey(currency.CurrencyCode))
                {
                    currency.UpdateExchangeRate(exchangeRate[currency.CurrencyCode]);
                }
            }
        }
    }
}
