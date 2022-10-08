using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Context.Seed
{
    public static class BasketProductSeed
    {
        public static void CreateBasketProductSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.BasketProduct>()
                .HasData(new Models.BasketProduct
                {
                    Id = 1,
                    ShoppingBasketId = 1,
                    ProductId = 1,
                    Quantity = 1,
                });

            modelBuilder.Entity<Models.BasketProduct>()
                .HasData(new Models.BasketProduct
                {
                    Id = 2,
                    ShoppingBasketId = 1,
                    ProductId = 2,
                    Quantity = 1,
                });

            modelBuilder.Entity<Models.BasketProduct>()
                .HasData(new Models.BasketProduct
                {
                    Id = 3,
                    ShoppingBasketId = 1,
                    ProductId = 3,
                    Quantity = 1,
                });
        }
    }
}
