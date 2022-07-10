using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Context.Configuration
{
    public class ShoppingBasketConfiguration : IEntityTypeConfiguration<Models.ShoppingBasket>
    {
        public void Configure(EntityTypeBuilder<Models.ShoppingBasket> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}