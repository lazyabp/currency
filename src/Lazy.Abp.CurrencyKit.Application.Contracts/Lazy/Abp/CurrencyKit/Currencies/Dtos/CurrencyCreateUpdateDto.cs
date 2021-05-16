using System;
using System.ComponentModel;

namespace Lazy.Abp.CurrencyKit.Currencies.Dtos
{
    [Serializable]
    public class CurrencyCreateUpdateDto
    {
        public string Name { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }

        public string CurrencySymbol { get; set; }

        public string CountryIsoCode { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsPrimary { get; set; }
    }
}