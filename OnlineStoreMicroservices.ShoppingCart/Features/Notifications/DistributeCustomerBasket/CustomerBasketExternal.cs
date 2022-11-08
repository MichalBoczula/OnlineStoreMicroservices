using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder;
using OnlineStoreMicroservices.ShoppingCart.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.DistributeCustomerBasket
{
    public class CustomerBasketExternal : IMapFrom<ShoppingBasketForCreationDto>
    {
        public int Id { get; set; }
        public List<BasketProductForCreationDto> BasketProducts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ShoppingBasketForCreationDto, CustomerBasketExternal>();
        }
    }
}
