using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket
{
    public class GetShoppingBasketByIdQuery : IRequest<ShoppingBasketDto>
    {
        public int Id { get; set; }
    }
}
