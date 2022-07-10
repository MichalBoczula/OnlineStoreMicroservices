using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Context.Seed
{
    public static class ShoppingBasketSeed
    {
        public static void CreateShoppingBasketSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.ShoppingBasket>()
                .HasData(new Models.ShoppingBasket
                {
                    DiscountCouponId = "",
                    Total = 450
                });
        }
    }
}
