using Microsoft.EntityFrameworkCore;
using OnlineStoreMicroservices.DiscountCoupon.Context.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Context
{
    public class DiscountCouponDbContext : DbContext
    {
        public DiscountCouponDbContext(DbContextOptions<DiscountCouponDbContext> options) : base(options)
        {

        }

        public DbSet<Models.DiscountCoupon> DiscountCoupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.CreateDiscountCouponSeed();
        }
    }
}
