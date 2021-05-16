using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.CurrencyKit.Currencies.Dtos
{
    public class ExchangeRateRequestDto
    {
        public decimal? Money { get; set; }

        public string FromCurrencyCode { get; set; }

        public string ToCurrencyCode { get; set; }
    }
}
