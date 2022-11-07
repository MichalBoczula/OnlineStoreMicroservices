using MediatR;
using MessageBus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.DistributeCustomerBasket
{
    public class DistributeCustomerBasketNotificationHandler : INotificationHandler<DistributeCustomerBasketNotification>
    {
        private readonly IMessageService messageService;

        public DistributeCustomerBasketNotificationHandler(IMessageService messageService)
        {
            this.messageService = messageService;
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
