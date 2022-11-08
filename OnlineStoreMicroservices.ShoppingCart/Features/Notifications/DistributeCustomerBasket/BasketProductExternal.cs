using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder;
using OnlineStoreMicroservices.ShoppingCart.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Notifications.DistributeCustomerBasket
{
    public class BasketProductExternal : IMapFrom<BasketProductForCreationDto>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketProductForCreationDto, BasketProductExternal>();
        }
    }
}
