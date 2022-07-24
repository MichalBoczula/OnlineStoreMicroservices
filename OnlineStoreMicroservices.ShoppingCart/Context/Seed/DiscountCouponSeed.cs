using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Context.Seed
{
    public static class DiscountCouponSeed
    {
        public static void CreateDiscountCouponSeed(this ModelBuilder modelBuilder)
        {
            var guid1 = "e0cfebf1-5fa6-49d0-a726-c5c4b2ce3de9";
            var guid2 = "3ed3adc6-7416-4d63-9048-9d1b92554c21";
            var guid3 = "fd918135-bcf1-4310-8b20-81365ad80862";

            modelBuilder.Entity<Models.DiscountCoupon>()
                .HasData(new Models.DiscountCoupon
                {
                    Id = 1,
                    IntegrationId = guid1,
                    Code = "ten",
                    Amount = 10,
                    IsActual = true
                });

            modelBuilder.Entity<Models.DiscountCoupon>()
                .HasData(new Models.DiscountCoupon
                {
                    Id = 2,
                    IntegrationId = guid2,
                    Code = "twenty",
                    Amount = 20,
                    IsActual = true
                });

            modelBuilder.Entity<Models.DiscountCoupon>()
                .HasData(new Models.DiscountCoupon
                {
                    Id =3,
                    IntegrationId = guid3,
                    Code = "thirty",
                    Amount = 30,
                    IsActual = true
                });
        }
    }
}
