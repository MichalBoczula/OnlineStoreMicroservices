using MediatR;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Services.SetCouponAsUnActive
{
    public class SetCouponAsUnActiveNotification : INotification
    {
        public string DiscountCouponGuid { get; set; }
    }
}
