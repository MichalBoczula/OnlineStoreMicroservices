using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Mapping;
using OnlineStoreMicroservices.ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder
{
    public class BasketProductForCreationDto : IMapFrom<BasketProduct>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int ShoppingBasketId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketProductForCreationDto, BasketProduct>().ReverseMap();
        }
    }
}
