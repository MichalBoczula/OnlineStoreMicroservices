using MediatR;
using OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.DistributeCustomerBasket
{
    public class DistributeCustomerBasketNotification : INotification
    {
        public ShoppingBasketForCreationDto ShoppingCart { get; set; }
    }
}
