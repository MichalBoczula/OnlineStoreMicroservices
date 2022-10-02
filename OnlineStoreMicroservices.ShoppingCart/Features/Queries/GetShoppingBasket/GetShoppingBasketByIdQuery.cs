using MediatR;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket
{
    public class GetShoppingBasketByIdQuery : IRequest<ShoppingBasketExternal>
    {
        public int Id { get; set; }
    }
}
