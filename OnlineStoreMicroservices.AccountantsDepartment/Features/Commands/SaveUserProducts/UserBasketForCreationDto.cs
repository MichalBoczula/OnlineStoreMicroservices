using AutoMapper;
using OnlineStoreMicroservices.AccountantsDepartment.Mapping;
using OnlineStoreMicroservices.AccountantsDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Features.Commands.SaveUserProducts
{
    public class UserBasketForCreationDto : IMapFrom<UserBasket>
    {
        public int Id { get; set; }
        public List<BasketProductForCreationDto> BasketProducts { get; set; }
        public UserBillForCreationDto UserBillRef { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserBasketForCreationDto, UserBasket>()
                .ForMember(x => x.BasketProducts, opt => opt.Ignore())
                .ForMember(x => x.UserBillRef, opt => opt.Ignore());
        }
    }
}
