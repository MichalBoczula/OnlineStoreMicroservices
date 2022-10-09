using MediatR;
using MessageBus.Services.Interfaces;
using OnlineStoreMicroservices.ShoppingCart.Features.Services.SetCouponAsUnActive;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.SetCouponAsUnActive
{
    public class SetCouponAsUnActiveNotificationHandler : INotificationHandler<SetCouponAsUnActiveNotification>
    {
        private readonly IMessageHandler _messageHandler;

        public SetCouponAsUnActiveNotificationHandler(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public async Task Handle(SetCouponAsUnActiveNotification notification, CancellationToken cancellationToken)
        {
        }
    }
}
