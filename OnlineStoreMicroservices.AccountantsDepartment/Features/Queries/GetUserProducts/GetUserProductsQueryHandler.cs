using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStoreMicroservices.AccountantsDepartment.Context.Abstract;
using OnlineStoreMicroservices.AccountantsDepartment.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Features.Queries.GetUserProducts
{
    public class GetUserProductsQueryHandler : QueryBase, IRequestHandler<GetUserProductsQuery, UserBasketDto>
    {
        public GetUserProductsQueryHandler(IAccountantDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<UserBasketDto> Handle(GetUserProductsQuery request, CancellationToken cancellationToken)
        {
            var elements = await _context.UserBaskets
                .Where(x => x.Id == request.UserBasketId)
                .Include(x => x.BasketProducts)
                .Include(x => x.UserBillRef)
                .FirstOrDefaultAsync();

            var result = _mapper.Map<UserBasketDto>(elements);
            return result;
        }
    }
}
