using System;
using System.Threading.Tasks;
using Lazy.Abp.CurrencyKit.Currencies.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.CurrencyKit.Currencies
{
    public interface ICurrencyAppService : IApplicationService, ITransientDependency
    {
        Task<CurrencyViewDto> GetByCurrencyCodeAsync(string code);

        Task<CurrencyViewDto> GetByCountryIsoCodeAsync(string countryCode);

        Task<PagedResultDto<CurrencyViewDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<decimal> ConvertExchangeRateAsync(GetExchangeRateRequestDto input);
    }
}