using AutoMapper;
using OnlineStoreMicroservices.AccountantsDepartment.Features.Commands.SaveUserProducts;
using OnlineStoreMicroservices.AccountantsDepartment.Mapping;

namespace OnlineStoreMicroservices.DiscountCoupon.Services
{
    public class BasketProductExternal : IMapFrom<UserBasketForCreationDto>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketProductExternal, BasketProductForCreationDto>();
        }
    }
}
