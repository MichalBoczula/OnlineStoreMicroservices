using MediatR;
using MessageBus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;
using OnlineStoreMicroservices.ShoppingCart.Features.Base;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.DistributeCustomerBasket
{
    public class DistributeCustomerBasketNotificationHandler : NotificationBase, INotificationHandler<DistributeCustomerBasketNotification>
    {
        public DistributeCustomerBasketNotificationHandler(IMessageService messageService) : base(messageService)
        {
        }

        public async Task Handle(DistributeCustomerBasketNotification notification, CancellationToken cancellationToken)
        {
            var updateOrder = new Dictionary<string, object>
                                  {
                                      { "Order", "UpdateOrder" },
                                  };
            var exchange = "OnlineStoreMicroServicesExchange";
            var shoppingCart = JsonConvert.SerializeObject(notification.ShoppingCart);
            this.messageService.SendMessage(shoppingCart, updateOrder, exchange);
        }
    }
}
