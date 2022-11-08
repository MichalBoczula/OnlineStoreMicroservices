using AutoMapper;
using OnlineStoreMicroservices.Warehouse.Mapping;
using OnlineStoreMicroservices.Warehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Features.Queries.GetUsersProducts
{
    public class BasketProductDto : IMapFrom<BasketProductDto>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketProduct, BasketProductDto>();
        }
    }
}
