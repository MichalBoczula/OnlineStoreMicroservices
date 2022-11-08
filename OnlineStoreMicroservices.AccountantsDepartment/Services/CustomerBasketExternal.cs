using AutoMapper;
using OnlineStoreMicroservices.AccountantsDepartment.Features.Commands.SaveUserProducts;
using OnlineStoreMicroservices.AccountantsDepartment.Mapping;
using System.Collections.Generic;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.DistributeCustomerBasket
{
    public class CustomerBasketExternal : IMapFrom<UserBasketForCreationDto>
    {
        public int Id { get; set; }
        public List<BasketProductForCreationDto> BasketProducts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerBasketExternal, UserBasketForCreationDto > ();
        }
    }
}
