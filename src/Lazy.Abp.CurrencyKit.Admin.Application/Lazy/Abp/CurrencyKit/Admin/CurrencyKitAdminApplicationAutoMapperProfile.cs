using AutoMapper;
using Lazy.Abp.CurrencyKit.Currencies;
using Lazy.Abp.CurrencyKit.Currencies.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.CurrencyKit.Admin
{
    public class CurrencyKitAdminApplicationAutoMapperProfile : Profile
    {
        public CurrencyKitAdminApplicationAutoMapperProfile()
        {
            CreateMap<Currency, CurrencyDto>();
            CreateMap<CurrencyCreateUpdateDto, Currency>(MemberList.Source);
        }
    }
}
