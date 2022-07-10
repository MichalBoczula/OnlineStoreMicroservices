using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Context.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Models.Product>
    {
        public void Configure(EntityTypeBuilder<Models.Product> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}