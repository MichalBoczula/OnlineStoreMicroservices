using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStoreMicroservices.ShoppingCart.Abstract;
using OnlineStoreMicroservices.ShoppingCart.Features.Base;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket
{
    public class GetShoppingBasketByIdQueryHandler : QueryBase, IRequestHandler<GetShoppingBasketByIdQuery, ShoppingBasketExternal>
    {
        public GetShoppingBasketByIdQueryHandler(IShoppingCartDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<ShoppingBasketExternal> Handle(GetShoppingBasketByIdQuery request, CancellationToken cancellationToken)
        {
            var shoppingBasket = await _context.ShoppingBaskets
                .Where(x => x.Id == request.Id)
                .Include(x => x.BasketProducts)
                .ThenInclude(x => x.ProductRef)
                .FirstOrDefaultAsync();

            var result = _mapper.Map<ShoppingBasketExternal>(shoppingBasket);

            return result;
        }
    }
}
