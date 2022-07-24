using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetShoppingBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingBasketController : BaseController
    {
        [HttpGet("{basketId}")]
        public async Task<ActionResult> GetShoppingBasketByIdAsync(int basketId)
        {
            var result = await Mediator.Send(new GetShoppingBasketByIdQuery() { Id = basketId});
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddShoppingBasketByIdAsync(int basketId)
        {
            return Ok();
        }
    }
}
