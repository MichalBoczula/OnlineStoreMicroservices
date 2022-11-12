using MediatR;
using OnlineStoreMicroservices.ShoppingCart.Features.Base;
using OnlineStoreMicroservices.ShoppingCart.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetDiscountCoupons
{
    public class GetDiscountCouponsQueryHandler : QueryBase, IRequestHandler<GetDiscountCouponsQuery, IEnumerable<DiscountCouponExternal>>
    {
        public GetDiscountCouponsQueryHandler(ISynchNotificationService synchNotificationService) : base(synchNotificationService)
        {
        }

        public async Task<IEnumerable<DiscountCouponExternal>> Handle(GetDiscountCouponsQuery request, CancellationToken cancellationToken)
        {
            var result = await _synchNotificationService.CheckIfCouponExists();
            return result;
        }
    }
}
