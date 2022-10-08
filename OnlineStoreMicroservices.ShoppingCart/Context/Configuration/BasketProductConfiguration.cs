using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreMicroservices.ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Context.Configuration
{
    public class BasketProductConfiguration : IEntityTypeConfiguration<Models.BasketProduct>
    {
        public void Configure(EntityTypeBuilder<Models.BasketProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ProductRef)
                .WithMany(x => x.BasketProducts)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.ShoppingBasketRef)
               .WithMany(x => x.BasketProducts)
               .HasForeignKey(x => x.ShoppingBasketId);
        }
    }
}