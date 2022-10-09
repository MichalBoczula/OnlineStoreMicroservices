using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStoreMicroservices.DiscountCoupon.Context.Abstract;
using OnlineStoreMicroservices.DiscountCoupon.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Features.Queries.GetCoupons
{
    public class GetCouponsQueryHandler : QueryBase, IRequestHandler<GetCouponsQuery, List<DiscountCouponExternal>>
    {
        public GetCouponsQueryHandler(IDiscountCouponDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<DiscountCouponExternal>> Handle(GetCouponsQuery request, CancellationToken cancellationToken)
        {
            var coupons = await _context.DiscountCoupons.ToListAsync();
            var result = _mapper.Map<List<Models.DiscountCoupon>, List<DiscountCouponExternal>>(coupons);
            return result;
        }
    }
}
