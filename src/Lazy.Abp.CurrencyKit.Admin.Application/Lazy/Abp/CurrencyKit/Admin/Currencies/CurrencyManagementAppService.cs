﻿using Lazy.Abp.CurrencyKit.Admin.Currencies.Dtos;
using Lazy.Abp.CurrencyKit.Admin.Permissions;
using Lazy.Abp.CurrencyKit.Currencies;
using Lazy.Abp.CurrencyKit.Currencies.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.EventBus.Distributed;

namespace Lazy.Abp.CurrencyKit.Admin.Currencies
{
    public class CurrencyManagementAppService : 
        CrudAppService<
            Currency, 
            CurrencyDto, 
            Guid, 
            CurrencyListRequestDto, 
            CurrencyCreateUpdateDto, 
            CurrencyCreateUpdateDto>,
        ICurrencyManagementAppService
    {
        protected override string GetPolicyName { get; set; } = CurrencyKitAdminPermissions.Currency.Default;
        protected override string GetListPolicyName { get; set; } = CurrencyKitAdminPermissions.Currency.Default;
        protected override string CreatePolicyName { get; set; } = CurrencyKitAdminPermissions.Currency.Create;
        protected override string UpdatePolicyName { get; set; } = CurrencyKitAdminPermissions.Currency.Update;
        protected override string DeletePolicyName { get; set; } = CurrencyKitAdminPermissions.Currency.Delete;

        private readonly ICurrencyRepository _repository;
        public IDistributedEventBus EventBus { get; set; }

        public CurrencyManagementAppService(
            ICurrencyRepository repository
        ) : base(repository)
        {
            _repository = repository;
            EventBus = NullDistributedEventBus.Instance;
        }

        [Authorize(CurrencyKitAdminPermissions.Currency.Default)]
        public async override Task<PagedResultDto<CurrencyDto>> GetListAsync(CurrencyListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(input.IsActive, input.IsPrimary, input.Filter);
            var currencies = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.IsActive, input.IsPrimary, input.Filter);

            return new PagedResultDto<CurrencyDto>(
                    totalCount,
                    ObjectMapper.Map<List<Currency>, List<CurrencyDto>>(currencies)
                );
        }

        [Authorize(CurrencyKitAdminPermissions.Currency.Create)]
        public async override Task<CurrencyDto> CreateAsync(CurrencyCreateUpdateDto input)
        {
            var exist = await _repository.IsCodeExistAsync(input.CurrencyCode);
            if (exist)
                throw new UserFriendlyException(L["CurrencyCodeIsExist"]);

            return await base.CreateAsync(input);
        }

        [Authorize(CurrencyKitAdminPermissions.Currency.Update)]
        public async override Task<CurrencyDto> UpdateAsync(Guid id, CurrencyCreateUpdateDto input)
        {
            var exist = await _repository.IsCodeExistAsync(input.CurrencyCode, id);
            if (exist)
                throw new UserFriendlyException(L["CurrencyCodeIsExist"]);

            return await base.UpdateAsync(id, input);
        }

        [Authorize(CurrencyKitAdminPermissions.Currency.Update)]
        public async Task SetAsActiveAsync(Guid id, SetAsActiveRequestDto input)
        {
            var currency = await _repository.GetAsync(id);
            currency.SetAsActive(input.IsActive);

            await _repository.UpdateAsync(currency);
        }

        [Authorize(CurrencyKitAdminPermissions.Currency.Update)]
        public async Task SetAsPrimaryAsync(Guid id, SetAsPrimaryRequestDto input)
        {
            var currency = await _repository.GetAsync(id);
            currency.SetAsPrimary(input.IsPrimary);

            await _repository.UpdateAsync(currency);
        }

        [Authorize(CurrencyKitAdminPermissions.Currency.Update)]
        public async Task UpdateExchangeRateAsync(Guid id, ExchangeRateUpdateRequestDto input)
        {
            var currency = await _repository.GetAsync(id);
            currency.UpdateExchangeRate(input.ExchangeRate);

            await _repository.UpdateAsync(currency);
        }

        /// <summary>
        /// 一件更新所有货币汇率
        /// </summary>
        /// <returns></returns>
        [Authorize(CurrencyKitAdminPermissions.Currency.Update)]
        public async Task AutoUpdateAllExchangeRateAsync()
        {
            await EventBus.PublishAsync(new AutoUpdateAllExchangeRateEto());
        }
    }
}
