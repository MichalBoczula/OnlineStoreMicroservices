using Microsoft.EntityFrameworkCore;
using OnlineStoreMicroservices.ShoppingCart.Context.Seed;
using OnlineStoreMicroservices.ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Context
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {

        }

        public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.CreateDiscountCouponSeed();
            modelBuilder.CreateShoppingBasketSeed();
            modelBuilder.CreateProductSeed();
            modelBuilder.CreateBasketProductSeed();
        }
    }
}
