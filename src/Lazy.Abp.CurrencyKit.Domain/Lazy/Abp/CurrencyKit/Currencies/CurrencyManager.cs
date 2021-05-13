using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Lazy.Abp.CurrencyKit.Currencies
{
    public class CurrencyManager : DomainService
    {
        private readonly ICurrencyRepository _repository;

        public CurrencyManager(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> ConvertExchangeRateAsync(string fromCurrencyCode, string toCurrencyCode)
        {
            if (fromCurrencyCode.Equals(toCurrencyCode, StringComparison.OrdinalIgnoreCase))
                return 1m;

            var fromCurrency = await _repository.GetByCodeAsync(fromCurrencyCode);
            var toCurrency = await _repository.GetByCodeAsync(toCurrencyCode);

            if (null == fromCurrency || fromCurrency.ExchangeRate == 0)
                return 0;

            if (toCurrency == null)
                return 1m;

            // 将采集到的价格转换成美元, 然后再将美元价格转换成目标汇率价格
            return 1m / fromCurrency.ExchangeRate * toCurrency.ExchangeRate;
        }
    }
}
