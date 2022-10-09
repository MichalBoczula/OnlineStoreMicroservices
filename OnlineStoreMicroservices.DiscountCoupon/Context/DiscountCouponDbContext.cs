using Microsoft.EntityFrameworkCore;
using OnlineStoreMicroservices.DiscountCoupon.Context.Abstract;
using OnlineStoreMicroservices.DiscountCoupon.Context.Seed;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Context
{
    public class DiscountCouponDbContext : DbContext, IDiscountCouponDbContext
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
