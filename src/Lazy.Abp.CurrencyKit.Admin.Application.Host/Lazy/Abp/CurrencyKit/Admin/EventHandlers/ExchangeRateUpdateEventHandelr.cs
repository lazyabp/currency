using Lazy.Abp.CurrencyKit.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Lazy.Abp.CurrencyKit.Admin.EventHandlers
{
    public class ExchangeRateUpdateEventHandelr : 
        IDistributedEventHandler<AutoUpdateAllExchangeRateEto>,
        ITransientDependency
    {
        private readonly ICurrencyRepository _reository;

        public ExchangeRateUpdateEventHandelr(ICurrencyRepository reository)
        {
            _reository = reository;
        }

        public Task HandleEventAsync(AutoUpdateAllExchangeRateEto eventData)
        {
            // 获取货币汇率并执行更新
            throw new NotImplementedException();
        }
    }
}
