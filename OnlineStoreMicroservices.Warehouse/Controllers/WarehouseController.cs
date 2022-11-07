using Microsoft.AspNetCore.Mvc;
using OnlineStoreMicroservices.Warehouse.Features.Commands.SaveUserProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Controllers
{
    public class WarehouseController : BaseController
    {
        [HttpPost("add")]
        public async Task<ActionResult> AddShoppingBasketAsync()
        {
            var obj = new UserBasketForCreationDto
            {
                BasketProducts = new List<BasketProductForCreationDto>()
                {
                    new BasketProductForCreationDto()
                    {
                        ProductId = 1,
                        Quantity = 2
                    }
                }
            };
            var result = await Mediator.Send(new SaveUserProductsCommand() { UserBasket = obj });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetShoppingBasketByIdAsync(int id)
        {
            throw new NotImplementedException();
            //var result = await Mediator.Send(new GetUserProductsQuery() { UserBasketId = id });
            //return Ok(result);
        }
    }
}
