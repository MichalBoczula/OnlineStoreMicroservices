using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Mapping;
using OnlineStoreMicroservices.ShoppingCart.Models;
using System.Collections.Generic;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket
{
    public class ShoppingBasketExternal : IMapFrom<ShoppingBasket>
    {
        public int Id { get; set; }
        public List<BasketProductDto> BasketProducts { get; set; }
        public string? DiscountCouponId { get; set; }
        public decimal Total { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ShoppingBasket, ShoppingBasketExternal>();
        }
    }
}
