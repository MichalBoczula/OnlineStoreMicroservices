using AutoMapper;
using OnlineStoreMicroservices.DiscountCoupon.Context.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Features.Common
{
    public class CommandBase
    {
        protected readonly IDiscountCouponDbContext _context;
        protected readonly IMapper _mapper;

        public CommandBase(IDiscountCouponDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}