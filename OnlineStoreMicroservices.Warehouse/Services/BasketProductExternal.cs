using AutoMapper;
using OnlineStoreMicroservices.Warehouse.Features.Commands.SaveUserProducts;
using OnlineStoreMicroservices.Warehouse.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Services
{
    public class BasketProductExternal : IMapFrom<UserBasketForCreationDto>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketProductExternal, BasketProductForCreationDto>();
        }
    }
}
