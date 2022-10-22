using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder
{
    public class CreateOrderCommandResult
    {
        public bool Result { get; set; }
        public string DiscoutCouponIntegrationId { get; set; }
    }
}
