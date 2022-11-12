using OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetDiscountCoupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Service.Abstract
{
    public interface ISynchNotificationService
    {
        Task<IEnumerable<DiscountCouponExternal>> CheckIfCouponExists();
        Task<bool> SetCouponAsUnActive(string integrationId);
    }
}
