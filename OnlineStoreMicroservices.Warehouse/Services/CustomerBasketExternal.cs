using AutoMapper;
using OnlineStoreMicroservices.Warehouse.Features.Commands.SaveUserProducts;
using OnlineStoreMicroservices.Warehouse.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Services
{
    public class CustomerBasketExternal : IMapFrom<UserBasketForCreationDto>
    {
        public int Id { get; set; }
        public List<BasketProductForCreationDto> BasketProducts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerBasketExternal, UserBasketForCreationDto>();
        }
    }
}
