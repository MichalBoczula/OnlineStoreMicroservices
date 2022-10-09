using AutoMapper;
using OnlineStoreMicroservices.DiscountCoupon.Context.Abstract;

namespace OnlineStoreMicroservices.DiscountCoupon.Features.Common
{
    public class QueryBase
    {
        protected readonly IDiscountCouponDbContext _context;
        protected readonly IMapper _mapper;

        public QueryBase(IDiscountCouponDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
