using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.CurrencyKit.Currencies
{
    public interface ICurrencyRepository : IRepository<Currency, Guid>
    {
        Task<bool> IsCodeExistAsync(string code, Guid? exceptId = null, CancellationToken cancellationToken = default);

        Task<Currency> GetByCodeAsync(string code, CancellationToken cancellationToken = default);

        Task<Currency> GetByCountryIsoCodeAsync(string isoCode, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            bool? isActive = null,
            bool? isPrimary = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<Currency>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            bool? isActive = null,
            bool? isPrimary = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}