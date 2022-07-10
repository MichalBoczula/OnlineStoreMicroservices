using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Context.Configuration
{
    public class DiscountCouponConfiguration : IEntityTypeConfiguration<Models.DiscountCoupon>
    {
        public void Configure(EntityTypeBuilder<Models.DiscountCoupon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.IntegrationId).IsUnique();
        }
    }
}