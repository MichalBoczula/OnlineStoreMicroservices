using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Mapping;
using OnlineStoreMicroservices.ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder
{
    public class ShoppingBasketForCreationDto : IMapFrom<ShoppingBasket>
    {
        public List<BasketProductForCreationDto> BasketProducts { get; set; }
        public string? DiscountCouponId { get; set; }
        public decimal Total { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ShoppingBasketForCreationDto, ShoppingBasket>()
                .ForMember(x => x.BasketProducts, prop => prop.Ignore());

            profile.CreateMap<ShoppingBasket, ShoppingBasketForCreationDto>()
                .ForMember(x => x.DiscountCouponId, prop => prop.Ignore())
                .ForMember(x => x.Total, prop => prop.Ignore());
        }
    }
}
