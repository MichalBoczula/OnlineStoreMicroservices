using AutoMapper;
using MediatR;
using OnlineStoreMicroservices.Warehouse.Context.Abstract;
using OnlineStoreMicroservices.Warehouse.Features.Base;
using OnlineStoreMicroservices.Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Features.Commands.SaveUserProducts
{
    public class SaveUserProductsCommandHandler : CommandBase, IRequestHandler<SaveUserProductsCommand, int>
    {
        public SaveUserProductsCommandHandler(IWarehouseDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> Handle(SaveUserProductsCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _context.BeginTransaction();

            try
            {
                var userBasket = _mapper.Map<UserBasketForCreationDto, UserBasket>(request.UserBasket);

                await _context.UserBaskets.AddAsync(userBasket);

                await _context.SaveChangesAsync(cancellationToken);


                var basketProducts = request.UserBasket.BasketProducts
                    .Select(x => new BasketProduct
                    {
                        Quantity = x.Quantity,
                        ProductId = x.ProductId,
                        UserBasketId = userBasket.Id
                    });

                await _context.BasketProducts.AddRangeAsync(basketProducts);

                await _context.SaveChangesAsync(cancellationToken);

                await _context.CommitTransaction(transaction, cancellationToken);

                return userBasket.Id;
            }
            catch (Exception e)
            {
                await _context.RollbackTransaction(transaction, cancellationToken);
                throw;
            }

        }
    }
}
