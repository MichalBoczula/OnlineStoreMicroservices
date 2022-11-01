﻿using AutoMapper;
using MediatR;
using OnlineStoreMicroservices.AccountantsDepartment.Context.Abstract;
using OnlineStoreMicroservices.AccountantsDepartment.Features.Base;
using OnlineStoreMicroservices.AccountantsDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Features.Commands.SaveUserProducts
{
    public class SaveCustomerProductsCommandHandler : CommandBase, IRequestHandler<SaveCustomerProductsCommand, int>
    {
        public SaveCustomerProductsCommandHandler(IAccountantDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> Handle(SaveCustomerProductsCommand request, CancellationToken cancellationToken)
        {
            var tran = await _context.BeginTransaction();
            var result = 0;
            try
            {
                var userBasket = _mapper.Map<UserBasket>(request.UserBasket);
                await _context.UserBaskets.AddAsync(userBasket);

                await _context.SaveChangesAsync(cancellationToken);

                if (userBasket.Id == 0)
                {
                    await _context.RollbackTransaction(tran, cancellationToken);
                    return 0;
                }
                else
                {
                    var basketProducts = userBasket.BasketProducts;
                    basketProducts.ForEach(x => x.UserBasketId = userBasket.Id);

                    await _context.BasketProducts.AddRangeAsync(basketProducts);

                    var userBill = userBasket.UserBillRef;
                    userBill.UserBasketId = userBasket.Id;

                    await _context.UserBills.AddAsync(userBill);

                    await _context.SaveChangesAsync(cancellationToken);

                    await _context.CommitTransaction(tran, cancellationToken);
                }
            }
            catch (Exception e)
            {
                await _context.RollbackTransaction(tran, cancellationToken);
                throw;
            }

            return result;
        }
    }
}