using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Features.Queries.GetUsersProducts
{
    public class GetUsersProductsQuery : IRequest<UserBasketDto>
    {
        public int Id { get; set; }
    }
}
