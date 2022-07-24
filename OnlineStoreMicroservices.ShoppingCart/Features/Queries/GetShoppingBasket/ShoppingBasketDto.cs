using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Mapping;
using OnlineStoreMicroservices.ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket
{
    public class ShoppingBasketDto : IMapFrom<ShoppingBasket>
    {
        public int Id { get; set; }
        public List<BasketProductDto> BasketProducts { get; set; }
        public string? DiscountCouponId { get; set; }
        public decimal Total { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ShoppingBasket, ShoppingBasketDto>();
        }
    }
}
