using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Features.Queries.GetUserProducts
{
    public class GetUserProductsQuery : IRequest<UserBasketDto>
    {
        public int UserBasketId { get; set; }
    }
}
