using AutoMapper;
using MediatR;
using OnlineStoreMicroservices.DiscountCoupon.Context.Abstract;
using OnlineStoreMicroservices.DiscountCoupon.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Features.Command.ActivateCoupon
{
    public class ActivateCouponCommandHandler : CommandBase, IRequestHandler<ActivateCouponCommand, bool>
    {
        public ActivateCouponCommandHandler(IDiscountCouponDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> Handle(ActivateCouponCommand request, CancellationToken cancellationToken)
        {
            var element = _context.DiscountCoupons.Where(x => x.IntegrationId == request.IntegrationId ).FirstOrDefault();

            if (element == null)
            {
                throw new KeyNotFoundException();
            }

            element.IsActual = true;

            try
            {
                var result = await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
