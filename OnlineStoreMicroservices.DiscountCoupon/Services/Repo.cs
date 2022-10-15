using OnlineStoreMicroservices.DiscountCoupon.Context.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Services
{
    public class Repo : IRepo
    {
        private readonly IDiscountCouponDbContext context;

        public Repo(IDiscountCouponDbContext context)
        {
            this.context = context;
        }

        public Task Test(string aaa)
        {
            return Task.CompletedTask;
        }
    }
}
