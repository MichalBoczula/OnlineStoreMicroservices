using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreMicroservices.AccountantsDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Context.Configuration
{
    public class UserBasketConfiguration : IEntityTypeConfiguration<UserBasket>
    {
        public void Configure(EntityTypeBuilder<UserBasket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.UserBillRef)
                .WithOne(x => x.UserBasketRef)
                .HasForeignKey<UserBill>(x => x.UserBasketId);
        }
    }
}
