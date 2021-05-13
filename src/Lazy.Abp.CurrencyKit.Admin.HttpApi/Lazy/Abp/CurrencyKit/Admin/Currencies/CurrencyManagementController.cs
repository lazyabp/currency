﻿using Lazy.Abp.CurrencyKit.Admin.Currencies.Dtos;
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
    [Area("currencykitadmin")]
    [ControllerName("Currency")]
    [Route("api/currencykit/currencies/admin")]
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
        public Task<PagedResultDto<CurrencyDto>> GetListAsync(GetCurrencyListInput input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<CurrencyDto> CreateAsync(CreateUpdateCurrencyDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CurrencyDto> UpdateAsync(Guid id, CreateUpdateCurrencyDto input)
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
        public Task SetAsPrimaryAsync(Guid id, SetAsPrimaryRequestDto input)
        {
            return _service.SetAsPrimaryAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/update-rate")]
        public Task UpdateExchangeRateAsync(Guid id, UpdateExchangeRateRequestDto input)
        {
            return _service.UpdateExchangeRateAsync(id, input);
        }
    }
}
