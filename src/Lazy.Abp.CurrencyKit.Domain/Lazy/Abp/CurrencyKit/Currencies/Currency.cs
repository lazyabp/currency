using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.CurrencyKit.Currencies
{
    public class Currency : AuditedAggregateRoot<Guid>
    {
        [NotNull]
        [MaxLength(CurrencyConsts.MaxNameLength)]
        public virtual string Name { get; protected set; }

        [Column(TypeName = "decimal(18, 10)")]
        public virtual decimal ExchangeRate { get; protected set; }

        [NotNull]
        [StringLength(CurrencyConsts.MaxCurrencyCodeLength)]
        public virtual string CurrencyCode { get; protected set; }

        public virtual string CurrencySymbol { get; protected set; }

        [StringLength(CurrencyConsts.MaxCountryIsoCodeLength)]
        public virtual string CountryIsoCode { get; protected set; }

        [MaxLength(CurrencyConsts.MaxIconLength)]
        public virtual string Icon { get; protected set; }

        [MaxLength(CurrencyConsts.MaxDescriptionLength)]
        public virtual string Description { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        public virtual bool IsActive { get; protected set; }

        public virtual bool IsPrimary { get; protected set; }

        protected Currency()
        {
        }

        public Currency(
            Guid id,
            [NotNull] string name,
            [NotNull] string currencyCode, 
            decimal exchangeRate,
            string currencySymbol,
            string countryIsoCode,
            string icon,
            string description,
            int displayOrder,
            bool isActive = true, 
            bool isPrimary = false
        ) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            CurrencyCode = Check.NotNullOrWhiteSpace(currencyCode, nameof(currencyCode));
            ExchangeRate = exchangeRate;
            CurrencySymbol = currencySymbol;
            CountryIsoCode = countryIsoCode;
            Icon = icon;
            Description = description;
            DisplayOrder = displayOrder;
            IsActive = isActive;
            IsPrimary = isPrimary;
        }

        public void UpdateExchangeRate(decimal exchangeRate)
        {
            ExchangeRate = exchangeRate;
        }

        public void SetAsActive(bool isActive = true)
        {
            IsActive = isActive;
        }

        public void SetAsPrimary(bool isPrimary = true)
        {
            IsPrimary = isPrimary;
        }
    }
}
