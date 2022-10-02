using MediatR;
using OnlineStoreMicroservices.ShoppingCart.Features.Services.SetCouponAsUnActive;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.SetCouponAsUnActive
{
    public class SetCouponAsUnActiveNotificationHandler : INotificationHandler<SetCouponAsUnActiveNotification>
    {
        public async Task Handle(SetCouponAsUnActiveNotification notification, CancellationToken cancellationToken)
        {

        }
    }
}
