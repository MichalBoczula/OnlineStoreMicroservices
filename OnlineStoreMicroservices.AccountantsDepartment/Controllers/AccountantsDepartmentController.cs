﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreMicroservices.AccountantsDepartment.Features.Commands.SaveUserProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Controllers
{
    public class AccountantsDepartmentController : BaseController
    {
        [HttpPost("add")]
        public async Task<ActionResult> AddShoppingBasketByIdAsync()
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
                },
                UserBillRef = new UserBillForCreationDto()
                {
                    Quantity = 2,
                    Total = 100
                }
            };
            var result = await Mediator.Send(new SaveCustomerProductsCommand() { UserBasket = obj});
            return Ok(result);
        }
    }
}
