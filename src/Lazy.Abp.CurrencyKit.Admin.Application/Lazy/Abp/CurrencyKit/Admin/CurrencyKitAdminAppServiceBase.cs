using Lazy.Abp.CurrencyKit.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CurrencyKit.Admin
{
    public abstract class CurrencyKitAdminAppServiceBase : ApplicationService
    {
        protected CurrencyKitAdminAppServiceBase()
        {
            ObjectMapperContext = typeof(CurrencyKitAdminApplicationModule);
            LocalizationResource = typeof(CurrencyKitResource);
        }
    }
}
