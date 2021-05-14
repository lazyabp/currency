using Lazy.Abp.CurrencyKit.Currencies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace Lazy.Abp.CurrencyKit.Admin.BackgroundWorkers
{
    public class ExchangeRateUpdateBackgroundWorker : AsyncPeriodicBackgroundWorkerBase
    {
        private readonly ICurrencyRepository _reository;

        public ExchangeRateUpdateBackgroundWorker(AbpAsyncTimer timer,
            IServiceScopeFactory serviceScopeFactory,
            ICurrencyRepository reository
        ) : base(timer, serviceScopeFactory)
        {
            _reository = reository;
            // 每x小时更新一次汇率
            Timer.Period = 12 * 3600;
        }

        protected override Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            // 获取货币汇率并执行更新
            throw new NotImplementedException();
        }
    }
}
