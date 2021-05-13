using System;
using Lazy.Abp.CurrencyKit.Permissions;
using Lazy.Abp.CurrencyKit.Currencies.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Volo.Abp;

namespace Lazy.Abp.CurrencyKit.Currencies
{
    [Authorize]
    public class CurrencyAppService : ApplicationService, ICurrencyAppService
    {
        private readonly ICurrencyRepository _repository;
        private readonly CurrencyManager _currencyManager;

        public CurrencyAppService(
            ICurrencyRepository repository,
            CurrencyManager currencyManager
        )
        {
            _repository = repository;
            _currencyManager = currencyManager;
        }

        public async Task<CurrencyViewDto> GetByCurrencyCodeAsync(string code)
        {
            var currency = await _repository.GetByCodeAsync(code);

            return ObjectMapper.Map<Currency, CurrencyViewDto>(currency);
        }

        public async Task<CurrencyViewDto> GetByCountryIsoCodeAsync(string countryCode)
        {
            var currency = await _repository.GetByCountryIsoCodeAsync(countryCode);

            return ObjectMapper.Map<Currency, CurrencyViewDto>(currency);
        }

        public async Task<PagedResultDto<CurrencyViewDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(true);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, true);

            return new PagedResultDto<CurrencyViewDto>(
                totalCount,
                ObjectMapper.Map<List<Currency>, List<CurrencyViewDto>>(list)
            );
        }

        public async Task<decimal> ConvertExchangeRateAsync(GetExchangeRateRequestDto input)
        {
            var exchangeRate = await _currencyManager.ConvertExchangeRateAsync(input.FromCurrencyCode, input.ToCurrencyCode);

            if (input.Money.HasValue & input.Money > 0)
                return input.Money.Value * exchangeRate;
            else
                return exchangeRate;
        }
    }
}
