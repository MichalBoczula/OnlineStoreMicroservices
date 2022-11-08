using MediatR;
using MessageBus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;
using OnlineStoreMicroservices.ShoppingCart.Features.Base;
using OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder;
using AutoMapper;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.DistributeCustomerBasket
{
    public class DistributeCustomerBasketNotificationHandler : NotificationBase, INotificationHandler<DistributeCustomerBasketNotification>
    {
        public DistributeCustomerBasketNotificationHandler(IMessageService messageService, IMapper mapper) : base(messageService, mapper)
        {
        }

        public async Task Handle(DistributeCustomerBasketNotification notification, CancellationToken cancellationToken)
        {
            var updateOrder = new Dictionary<string, object>
                                  {
                                      { "Order", "UpdateOrder" },
                                  };
            var exchange = "OnlineStoreMicroServicesExchange";
            var customerBasket = _mapper.Map< ShoppingBasketForCreationDto, CustomerBasketExternal> (notification.ShoppingCart);
            var message = JsonConvert.SerializeObject(customerBasket);
           
            _messageService.SendMessage(message, updateOrder, exchange);
        }
    }
}
