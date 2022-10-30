using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreMicroservices.Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Context.Configuration
{
    public class BasketProductConfiguration : IEntityTypeConfiguration<BasketProduct>
    {
        public void Configure(EntityTypeBuilder<BasketProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ProductRef)
                .WithMany(x => x.BasketProducts)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.UserBasketRef)
               .WithMany(x => x.BasketProducts)
               .HasForeignKey(x => x.UserBasketId);
        }
    }
}
