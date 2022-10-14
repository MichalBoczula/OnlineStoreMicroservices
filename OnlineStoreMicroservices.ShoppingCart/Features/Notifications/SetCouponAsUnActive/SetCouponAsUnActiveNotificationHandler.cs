using System.Collections.Generic;

using MediatR;
using MessageBus.Services.Interfaces;
using OnlineStoreMicroservices.ShoppingCart.Features.Services.SetCouponAsUnActive;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.SetCouponAsUnActive
{
    public class SetCouponAsUnActiveNotificationHandler : INotificationHandler<SetCouponAsUnActiveNotification>
    {
        private readonly IMessageService messageService;

        public SetCouponAsUnActiveNotificationHandler(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public async Task Handle(SetCouponAsUnActiveNotification notification, CancellationToken cancellationToken)
        {
            var shoppingCartHeader = new Dictionary<string, object>
             {
                 { "UpdateDiscountCoupon", "coupon" },
             };
            var exchange = "OnlineStoreMicroServicesExchange";
            this.messageService.SendMessage(notification.DiscountCouponGuid, shoppingCartHeader, exchange);
        }
    }
}
