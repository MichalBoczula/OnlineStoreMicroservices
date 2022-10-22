using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket
{
    public class GetShoppingBasketByIdQueryValidator : AbstractValidator<GetShoppingBasketByIdQuery>
    {
        public GetShoppingBasketByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
