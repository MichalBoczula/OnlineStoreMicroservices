using Microsoft.AspNetCore.Mvc;
using OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder;
using OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket;
using System.Collections.Generic;
using System.Threading.Tasks;

using MessageBus.Services.Interfaces;

using OnlineStoreMicroservices.ShoppingCart.Features.Services.SetCouponAsUnActive;

namespace OnlineStoreMicroservices.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingBasketController : BaseController
    {
        [HttpGet("{basketId}")]
        public async Task<ActionResult> GetShoppingBasketByIdAsync(int basketId)
        {
            var result = await Mediator.Send(new GetShoppingBasketByIdQuery() { Id = basketId });
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddShoppingBasketByIdAsync()
        {
            var result = await Mediator.Send(new CreateOrderCommand()
            {
                ShoppingCart = new ShoppingBasketForCreationDto()
                {
                    DiscountCouponId = "e0cfebf1-5fa6-49d0-a726-c5c4b2ce3de9",
                    Total = 10,
                    BasketProducts = new List<BasketProductForCreationDto>()
                    {
                       new BasketProductForCreationDto()
                       {
                           ProductId = 1,
                           Quantity = 1,
                           Total = 10
                       },
                        new BasketProductForCreationDto()
                       {
                           ProductId = 2,
                           Quantity = 1,
                           Total = 10
                       }
                    }
                }
            });
            return Ok();
        }
    }
}
