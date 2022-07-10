using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Context.Seed
{
    public static class ProductSeed
    {
        public static void CreateProductSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Product>()
                .HasData(new Models.Product
                {
                    Name ="Boots one",
                    Price = 100m
                });

            modelBuilder.Entity<Models.Product>()
                .HasData(new Models.Product
                {
                    Name = "Boots two",
                    Price = 150m
                });

            modelBuilder.Entity<Models.Product>()
                .HasData(new Models.Product
                {
                    Name = "Boots three",
                    Price = 200m
                });
        }
    }
}