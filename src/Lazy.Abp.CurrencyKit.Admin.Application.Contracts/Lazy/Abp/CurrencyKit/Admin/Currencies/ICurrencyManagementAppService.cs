using Lazy.Abp.CurrencyKit.Admin.Currencies.Dtos;
using Lazy.Abp.CurrencyKit.Currencies.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CurrencyKit.Admin.Currencies
{
    public interface ICurrencyManagementAppService :
        ICrudAppService<
            CurrencyDto,
            Guid,
            GetCurrencyListInput,
            CreateUpdateCurrencyDto,
            CreateUpdateCurrencyDto>
    {
        Task SetAsActiveAsync(Guid id, SetAsActiveRequestDto input);

        Task SetAsPrimaryAsync(Guid id, SetAsPrimaryRequestDto input);

        Task UpdateExchangeRateAsync(Guid id, UpdateExchangeRateRequestDto input);
    }
}
