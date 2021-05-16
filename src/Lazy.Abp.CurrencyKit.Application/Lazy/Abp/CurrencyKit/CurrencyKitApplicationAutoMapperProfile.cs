using AutoMapper;
using Lazy.Abp.CurrencyKit.Currencies;
using Lazy.Abp.CurrencyKit.Currencies.Dtos;

namespace Lazy.Abp.CurrencyKit
{
    public class CurrencyKitApplicationAutoMapperProfile : Profile
    {
        public CurrencyKitApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Currency, CurrencyViewDto>();
        }
    }
}