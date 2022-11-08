using AutoMapper;
using OnlineStoreMicroservices.Warehouse.Mapping;
using OnlineStoreMicroservices.Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Features.Queries.GetUsersProducts
{
    public class UserBasketDto : IMapFrom<UserBasket>
    {
        public int Id { get; set; }
        public List<BasketProductDto> BasketProducts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserBasket, UserBasketDto>();
        }
    }
}
