using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Context.Abstract
{
    public interface IDiscountCouponDbContext
    {
        DbSet<Models.DiscountCoupon> DiscountCoupons { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
