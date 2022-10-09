using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Features.Command.DeactivateCoupon
{
    public class DeactivateCouponCommand : IRequest<bool>
    {
        public string IntegrationId { get; set; }
    }
}
