using Lazy.Abp.Core;
using Lazy.Abp.CurrencyKit.Currencies;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace Lazy.Abp.CurrencyKit.Admin.BackgroundWorkers
{
    public class ExchangeRateUpdateBackgroundWorker : AsyncPeriodicBackgroundWorkerBase
    {
        private readonly ICurrencyRepository _reository;
        private readonly IExchangeRateApiService _exchangeRateApiService;

        public ExchangeRateUpdateBackgroundWorker(AbpAsyncTimer timer,
            IServiceScopeFactory serviceScopeFactory,
            ICurrencyRepository reository,
            IExchangeRateApiService exchangeRateApiService
        ) : base(timer, serviceScopeFactory)
        {
            _reository = reository;
            _exchangeRateApiService = exchangeRateApiService;

            // 每x小时更新一次汇率
            Timer.Period = 12 * 3600;
        }

        protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
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
