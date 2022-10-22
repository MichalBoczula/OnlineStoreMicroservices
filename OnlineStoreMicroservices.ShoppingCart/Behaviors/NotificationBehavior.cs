using MediatR;
using MediatR.Pipeline;
using MessageBus.Services.Interfaces;
using OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Behaviors
{
    public class NotificationBehavior<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly IMessageService _messageService;

        public NotificationBehavior(IMessageService messageService)
        {
            this._messageService = messageService;
        }

        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            var a = request;
            var t = response;

            var h = t as ShoppingBasketExternal;
            
            Debug.WriteLine("rawrrr");
            
            return Task.CompletedTask;
        }
    }
}
