using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Features.Command.ActivateCoupon
{
    public class ActivateCouponCommand : IRequest<bool>
    {
        public string IntegrationId  { get; set; }
    }
}
