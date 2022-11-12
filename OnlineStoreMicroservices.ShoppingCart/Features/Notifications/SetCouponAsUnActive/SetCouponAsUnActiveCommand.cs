using MediatR;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Services.SetCouponAsUnActive
{
    public class SetCouponAsUnActiveCommand : IRequest<bool>
    {
        public string DiscountCouponIntegrationId { get; set; }
    }
}
