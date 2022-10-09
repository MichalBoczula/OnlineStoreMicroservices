using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Features.Queries
{
    public class GetCouponsQuery : IRequest<List<DiscountCouponExternal>>
    {
    }
}
