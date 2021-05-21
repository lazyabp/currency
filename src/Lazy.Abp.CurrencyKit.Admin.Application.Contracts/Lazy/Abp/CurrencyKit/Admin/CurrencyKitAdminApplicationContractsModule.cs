﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CurrencyKit.Admin
{
    [DependsOn(
        typeof(CurrencyKitApplicationContractsModule),
        typeof(CurrencyKitDomainSharedModule)
        )]
    public class CurrencyKitAdminApplicationContractsModule : AbpModule
    {
    }
}
