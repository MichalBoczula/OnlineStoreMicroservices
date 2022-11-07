using AutoMapper;
using MediatR;
using OnlineStoreMicroservices.ShoppingCart.Context.Abstract;
using OnlineStoreMicroservices.ShoppingCart.Features.Base;
using OnlineStoreMicroservices.ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : CommandBase, IRequestHandler<CreateOrderCommand, CreateOrderCommandResult>
    {
        public CreateOrderCommandHandler(IShoppingCartDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _context.BeginTransaction();

            var commandResult = new CreateOrderCommandResult()
            {
                IsDiscount = false,
                DiscoutCouponIntegrationId = string.Empty,
                ShoppingCartToDistribute = null
            };

            try
            {
                var shoppingCart = _mapper.Map<ShoppingBasketForCreationDto, ShoppingBasket>(request.ShoppingCart);
                await _context.ShoppingBaskets.AddAsync(shoppingCart);
                await _context.SaveChangesAsync(cancellationToken);

                var products = _mapper.Map<List<BasketProductForCreationDto>, List<BasketProduct>>(request.ShoppingCart.BasketProducts);
                products = products.Select(x => new BasketProduct()
                {
                    ProductId = x.ProductId,
                    ShoppingBasketId = shoppingCart.Id,
                    Quantity = x.Quantity,
                }).ToList();

                await _context.BasketProducts.AddRangeAsync(products);

                await _context.SaveChangesAsync(cancellationToken);

                await _context.CommitTransaction(transaction, cancellationToken);

                return new CreateOrderCommandResult
                {
                    IsDiscount = !string.IsNullOrWhiteSpace(request.ShoppingCart.DiscountCouponId),
                    DiscoutCouponIntegrationId = string.IsNullOrWhiteSpace(shoppingCart.DiscountCouponId) ? string.Empty : shoppingCart.DiscountCouponId,
                    ShoppingCartToDistribute = request.ShoppingCart
                };
            }
            catch (Exception e)
            {
                await _context.RollbackTransaction(transaction, cancellationToken);
                throw;
            }
        }
    }
}
