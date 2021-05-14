using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Lazy.Abp.CurrencyKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.CurrencyKit.Currencies
{
    public class CurrencyRepository : EfCoreRepository<ICurrencyKitDbContext, Currency, Guid>, ICurrencyRepository
    {
        public CurrencyRepository(IDbContextProvider<ICurrencyKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<bool> IsCodeExistAsync(string code, Guid? exceptId = null, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .Where(m => m.CurrencyCode == code)
                .WhereIf(exceptId.HasValue, e => e.Id != exceptId)
                .AnyAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Currency> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .Where(m => m.CurrencyCode == code)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Currency> GetByCountryIsoCodeAsync(string isoCode, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .Where(m => m.CountryIsoCode == isoCode)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Currency>> GetListAsync(
            bool? isActive = null,
            DateTime? startLastUpdateTime = null,
            DateTime? endLastUpdateTime = null
        )
        {
            return await (await GetQueryableAsync())
                .WhereIf(isActive.HasValue, q => q.IsActive == isActive)
                .WhereIf(startLastUpdateTime.HasValue, q => q.LastModificationTime >= startLastUpdateTime.Value.Date)
                .WhereIf(endLastUpdateTime.HasValue, q => q.LastModificationTime < endLastUpdateTime.Value.AddDays(1).Date)
                .ToListAsync();
        }

        public async Task<long> GetCountAsync(
            bool? isActive = null,
            bool? isPrimary = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(isActive, isPrimary, filter);

            var totalCount = await query.LongCountAsync(GetCancellationToken(cancellationToken));

            return totalCount;
        }

        public async Task<List<Currency>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            bool? isActive = null,
            bool? isPrimary = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(isActive, isPrimary, filter);

            var broadcasts = await query.OrderBy(sorting ?? "displayOrder asc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return broadcasts;
        }

        protected async Task<IQueryable<Currency>> GetListQuery(
            bool? isActive = null,
            bool? isPrimary = null,
            string filter = null
        )
        {
            return (await GetQueryableAsync())
                .AsNoTracking()
                .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                .WhereIf(isPrimary.HasValue, e => e.IsPrimary == isPrimary)
                .WhereIf(
                    !string.IsNullOrEmpty(filter), 
                    e => false 
                    || e.Name.Contains(filter) 
                    || e.CurrencyCode.Contains(filter)
                    || e.CountryIsoCode.Contains(filter)
                    || e.Description.Contains(filter)
                );
        }
    }
}