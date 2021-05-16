using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CurrencyKit.Currencies.Dtos
{
    public class CurrencyListRequestDto : PagedAndSortedResultRequestDto
    {
        public bool? IsActive { get; set; }

        public bool? IsPrimary { get; set; }

        public string Filter { get; set; }
    }
}
