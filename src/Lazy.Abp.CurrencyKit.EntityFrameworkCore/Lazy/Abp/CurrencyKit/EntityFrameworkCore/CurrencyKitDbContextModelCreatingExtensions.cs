using Lazy.Abp.CurrencyKit.Currencies;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.CurrencyKit.EntityFrameworkCore
{
    public static class CurrencyKitDbContextModelCreatingExtensions
    {
        public static void ConfigureCurrencyKit(
            this ModelBuilder builder,
            Action<CurrencyKitModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CurrencyKitModelBuilderConfigurationOptions(
                CurrencyKitDbProperties.DbTablePrefix,
                CurrencyKitDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<Currency>(b =>
            {
                b.ToTable(options.TablePrefix + "Currencies", options.Schema);
                b.ConfigureByConvention();
                b.HasIndex(m => m.CurrencyCode);
                b.HasIndex(m => m.CountryIsoCode);

                /* Configure more properties here */
            });
        }
    }
}
