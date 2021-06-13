using Lazy.Abp.CurrencyKit.Admin.Currencies.Dtos;
using Lazy.Abp.CurrencyKit.Currencies.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.CurrencyKit.Admin.Currencies
{
    [RemoteService(Name = CurrencyKitAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("currencykit")]
    [ControllerName("Currency")]
    [Route("api/currencykit/currencies/management")]
    public class CurrencyManagementController : AbpController, ICurrencyManagementAppService
    {
        private readonly ICurrencyManagementAppService _service;

        public CurrencyManagementController(ICurrencyManagementAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CurrencyDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CurrencyDto>> GetListAsync(CurrencyListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<CurrencyDto> CreateAsync(CurrencyCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CurrencyDto> UpdateAsync(Guid id, CurrencyCreateUpdateDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}/set-as-active")]
        public Task SetAsActiveAsync(Guid id, SetAsActiveRequestDto input)
        {
            return _service.SetAsActiveAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/set-as-primary")]
        public Task SetAsPrimaryAsync(Guid id)
        {
            return _service.SetAsPrimaryAsync(id);
        }

        [HttpPut]
        [Route("{id}/update-rate")]
        public Task UpdateExchangeRateAsync(Guid id, ExchangeRateUpdateRequestDto input)
        {
            return _service.UpdateExchangeRateAsync(id, input);
        }

        [HttpPut]
        [Route("update-all-rates")]
        public Task AutoUpdateAllExchangeRateAsync()
        {
            return _service.AutoUpdateAllExchangeRateAsync();
        }
    }
}
