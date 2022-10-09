using AutoMapper;
using MediatR;
using OnlineStoreMicroservices.DiscountCoupon.Context.Abstract;
using OnlineStoreMicroservices.DiscountCoupon.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Features.Command.DeactivateCoupon
{
    public class DeactivateCouponCommandHandler : CommandBase, IRequestHandler<DeactivateCouponCommand, bool>
    {
        public DeactivateCouponCommandHandler(IDiscountCouponDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> Handle(DeactivateCouponCommand request, CancellationToken cancellationToken)
        {
            var element = _context.DiscountCoupons.Where(x => x.IntegrationId == request.IntegrationId).FirstOrDefault();

            if (element == null)
            {
                throw new KeyNotFoundException();
            }

            element.IsActual = false;

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
