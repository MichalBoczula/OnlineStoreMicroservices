using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Features.Commands.SaveUserProducts
{
    public class SaveCustomerProductsCommand : IRequest<int>
    {
        public UserBasketForCreationDto UserBasket { get; set; }
    }
}
