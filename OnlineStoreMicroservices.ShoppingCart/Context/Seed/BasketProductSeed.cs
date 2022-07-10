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
                    ShoppingBasketId = 1,
                    ProductId = 1,
                    Quantity = 1,
                    Total = 100m
                });

            modelBuilder.Entity<Models.BasketProduct>()
                .HasData(new Models.BasketProduct
                {
                    ShoppingBasketId = 1,
                    ProductId = 2,
                    Quantity = 1,
                    Total = 150m
                });

            modelBuilder.Entity<Models.BasketProduct>()
                .HasData(new Models.BasketProduct
                {
                    ShoppingBasketId = 1,
                    ProductId = 3,
                    Quantity = 1,
                    Total = 200m
                });
        }
    }
}
