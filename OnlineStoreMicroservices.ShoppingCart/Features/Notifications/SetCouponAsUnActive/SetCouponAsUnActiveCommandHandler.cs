using System.Collections.Generic;
using MediatR;
using MessageBus.Services.Interfaces;
using OnlineStoreMicroservices.ShoppingCart.Features.Services.SetCouponAsUnActive;
using System.Threading;
using System.Threading.Tasks;
using OnlineStoreMicroservices.ShoppingCart.Features.Base;
using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Service.Abstract;
using OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetDiscountCoupons;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.SetCouponAsUnActive
{
    public class SetCouponAsUnActiveCommandHandler : CommandBase, IRequestHandler<SetCouponAsUnActiveCommand, bool>
    {
        public SetCouponAsUnActiveCommandHandler(ISynchNotificationService synchNotificationService) : base(synchNotificationService)
        {
        }

        public async Task<bool> Handle(SetCouponAsUnActiveCommand request, CancellationToken cancellationToken)
        {
            var result = await _synchNotificationService.SetCouponAsUnActive(request.DiscountCouponIntegrationId);
            return result;
        }
    }
}
