using AutoMapper;
using MediatR;
using OnlineStoreMicroservices.ShoppingCart.Abstract;
using OnlineStoreMicroservices.ShoppingCart.Features.Base;
using OnlineStoreMicroservices.ShoppingCart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : CommandBase, IRequestHandler<CreateOrderCommand, bool>
    {
        public CreateOrderCommandHandler(IShoppingCartDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var shoppingCart = _mapper.Map<ShoppingBasketForCreationDto, ShoppingBasket>(request.ShoppingCart);
            await _context.ShoppingBaskets.AddAsync(shoppingCart);
            var shoppingCartId = await _context.SaveChangesAsync(cancellationToken);

            var products = _mapper.Map<List<BasketProductForCreationDto>, List<BasketProduct>>(request.ShoppingCart.BasketProducts);
            products = products.Select(x => new BasketProduct()
            {
                ProductId = x.ProductId,
                ShoppingBasketId = shoppingCart.Id,
                Quantity = x.Quantity,
            }).ToList();

            await _context.BasketProducts.AddRangeAsync(products);
            var result = await _context.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
