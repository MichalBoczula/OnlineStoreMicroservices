using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetDiscountCoupons
{
    public class GetDiscountCouponsQuery : IRequest<IEnumerable<DiscountCouponExternal>>
    {
    }
}
