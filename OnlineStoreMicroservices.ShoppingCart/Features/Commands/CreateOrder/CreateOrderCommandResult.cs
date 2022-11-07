using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder
{
    public class CreateOrderCommandResult
    {
        public bool IsDiscount { get; set; }
        public string DiscoutCouponIntegrationId { get; set; }
        public ShoppingBasketForCreationDto ShoppingCartToDistribute { get; set; }
    }
}
