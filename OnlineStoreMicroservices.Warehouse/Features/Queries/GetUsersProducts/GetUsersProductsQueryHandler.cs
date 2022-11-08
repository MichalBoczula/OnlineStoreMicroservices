using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStoreMicroservices.Warehouse.Context.Abstract;
using OnlineStoreMicroservices.Warehouse.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Features.Queries.GetUsersProducts
{
    public class GetUsersProductsQueryHandler : QueryBase, IRequestHandler<GetUsersProductsQuery, UserBasketDto>
    {
        public GetUsersProductsQueryHandler(IWarehouseDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<UserBasketDto> Handle(GetUsersProductsQuery request, CancellationToken cancellationToken)
        {
            var obj = await _context.UserBaskets
                .Include(x => x.BasketProducts)
                .FirstOrDefaultAsync(cancellationToken);
            var result = _mapper.Map<UserBasketDto>(obj);
            
            return result;
        }
    }
}
