using AutoMapper;
using OnlineStoreMicroservices.Warehouse.Mapping;
using OnlineStoreMicroservices.Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Features.Commands.SaveUserProducts
{
    public class UserBasketForCreationDto : IMapFrom<UserBasket>
    {
        public int Id { get; set; }
        public List<BasketProductForCreationDto> BasketProducts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserBasketForCreationDto, UserBasket>()
                .ForMember(x => x.BasketProducts, opt => opt.Ignore());
        }
    }
}
