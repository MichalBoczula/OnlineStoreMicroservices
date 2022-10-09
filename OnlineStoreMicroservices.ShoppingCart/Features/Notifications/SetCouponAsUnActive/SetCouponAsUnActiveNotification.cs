using MediatR;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Services.SetCouponAsUnActive
{
    public class SetCouponAsUnActiveNotification : INotification
    {
        public int DiscountCouponId { get; set; }
    }
}
