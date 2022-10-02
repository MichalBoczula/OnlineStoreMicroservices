using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Mapping;
using OnlineStoreMicroservices.ShoppingCart.Models;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket
{
    public class BasketProductDto : IMapFrom<BasketProduct>
    {
        public int Id { get; set; }
        public ProductDto ProductRef { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketProduct, BasketProductDto>();
        }
    }
}
