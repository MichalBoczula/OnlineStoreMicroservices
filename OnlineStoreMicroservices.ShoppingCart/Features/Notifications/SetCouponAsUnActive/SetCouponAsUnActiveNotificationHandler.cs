using System.Collections.Generic;

using MediatR;
using MessageBus.Services.Interfaces;
using OnlineStoreMicroservices.ShoppingCart.Features.Services.SetCouponAsUnActive;
using System.Threading;
using System.Threading.Tasks;
using OnlineStoreMicroservices.ShoppingCart.Features.Base;
using AutoMapper;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.SetCouponAsUnActive
{
    public class SetCouponAsUnActiveNotificationHandler : NotificationBase, INotificationHandler<SetCouponAsUnActiveNotification>
    {
        public SetCouponAsUnActiveNotificationHandler(IMessageService messageService, IMapper mapper) : base(messageService, mapper)
        {
        }

        public async Task Handle(SetCouponAsUnActiveNotification notification, CancellationToken cancellationToken)
        {
            var shoppingCartHeader = new Dictionary<string, object>
             {
                 { "UpdateDiscountCoupon", "coupon" },
             };
            var exchange = "OnlineStoreMicroServicesExchange";
            this._messageService.SendMessage(notification.DiscountCouponIntegrationId, shoppingCartHeader, exchange);
        }
    }
}
