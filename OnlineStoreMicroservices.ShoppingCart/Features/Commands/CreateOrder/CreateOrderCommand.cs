using MediatR;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public ShoppingBasketForCreationDto ShoppingCart { get; set; }
    }
}
