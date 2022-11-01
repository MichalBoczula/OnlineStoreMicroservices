using AutoMapper;
using OnlineStoreMicroservices.AccountantsDepartment.Mapping;
using OnlineStoreMicroservices.AccountantsDepartment.Models;

namespace OnlineStoreMicroservices.AccountantsDepartment.Features.Commands.SaveUserProducts
{
    public class BasketProductForCreationDto : IMapFrom<BasketProduct>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketProductForCreationDto, BasketProduct>();
        }
    }
}