using MediatR;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResult>
    {
        public ShoppingBasketForCreationDto ShoppingCart { get; set; }
    }
}
