using AutoMapper;
using OnlineStoreMicroservices.Warehouse.Mapping;
using OnlineStoreMicroservices.Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Features.Commands.SaveUserProducts
{
    public class BasketProductForCreationDto : IMapFrom<BasketProduct>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketProductForCreationDto, BasketProduct>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.ProductRef, opt => opt.Ignore())
                .ForMember(x => x.UserBasketRef, opt => opt.Ignore());
        }
    }
}
