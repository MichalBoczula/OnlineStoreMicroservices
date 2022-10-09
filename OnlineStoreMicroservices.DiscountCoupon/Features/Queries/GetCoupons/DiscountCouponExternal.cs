using AutoMapper;
using OnlineStoreMicroservices.DiscountCoupon.Mapping;

namespace OnlineStoreMicroservices.DiscountCoupon.Features.Queries
{
    public class DiscountCouponExternal : IMapFrom<Models.DiscountCoupon>
    {
        public int Id { get; set; }
        public string IntegrationId { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public bool IsActual { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Models.DiscountCoupon, DiscountCouponExternal>();
        }
    }
}