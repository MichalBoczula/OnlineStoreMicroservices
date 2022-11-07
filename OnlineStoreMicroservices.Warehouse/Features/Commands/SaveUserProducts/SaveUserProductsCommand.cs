using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Features.Commands.SaveUserProducts
{
    public class SaveUserProductsCommand : IRequest<int>
    {
        public UserBasketForCreationDto UserBasket{ get; set; }
    }
}
