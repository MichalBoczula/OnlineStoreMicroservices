using AutoMapper;
using OnlineStoreMicroservices.AccountantsDepartment.Mapping;
using OnlineStoreMicroservices.AccountantsDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Features.Queries.GetUserProducts
{
    public class UserBasketDto : IMapFrom<UserBasket>
    {
        public int Id { get; set; }
        public List<BasketProductDto> BasketProducts { get; set; }
        public UserBillDto UserBillRef { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserBasket, UserBasketDto>();
        }
    }
}
