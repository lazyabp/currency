using Lazy.Abp.CurrencyKit.Currencies.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CurrencyKit.Currencies
{
    [RemoteService(Name = CurrencyKitRemoteServiceConsts.RemoteServiceName)]
    [Area("currencykit")]
    [ControllerName("Currency")]
    [Route("api/currencykit/currencies")]
    public class CurrencyController : CurrencyKitController, ICurrencyAppService
    {
        private readonly ICurrencyAppService _currencyAppService;

        public CurrencyController(ICurrencyAppService currencyAppService)
        {
            _currencyAppService = currencyAppService;
        }

        [HttpGet]
        [Route("by-code/{code}")]
        public Task<CurrencyViewDto> GetByCurrencyCodeAsync(string code)
        {
            return _currencyAppService.GetByCurrencyCodeAsync(code);
        }

        [HttpGet]
        [Route("by-country-code/{countryCode}")]
        public Task<CurrencyViewDto> GetByCountryIsoCodeAsync(string countryCode)
        {
            return _currencyAppService.GetByCountryIsoCodeAsync(countryCode);
        }

        [HttpGet]
        public Task<PagedResultDto<CurrencyViewDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _currencyAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("exchange-rate-convert")]
        public Task<decimal> ConvertExchangeRateAsync(GetExchangeRateRequestDto input)
        {
            return _currencyAppService.ConvertExchangeRateAsync(input);
        }
    }
}
