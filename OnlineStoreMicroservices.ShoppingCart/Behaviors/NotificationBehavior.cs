using MediatR;
using MediatR.Pipeline;
using MessageBus.Services.Interfaces;
using OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder;
using OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket;
using OnlineStoreMicroservices.ShoppingCart.Features.Services.SetCouponAsUnActive;
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
        private readonly IMediator _mediator;

        public NotificationBehavior(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            if (response is CreateOrderCommandResult)
            {
                var createOrderCommandResult = response as CreateOrderCommandResult;

                if (createOrderCommandResult.Result)
                {
                    await _mediator.Publish(new SetCouponAsUnActiveNotification()
                    {
                        DiscountCouponIntegrationId = createOrderCommandResult.DiscoutCouponIntegrationId
                    });
                }
            }
        }
    }
}
