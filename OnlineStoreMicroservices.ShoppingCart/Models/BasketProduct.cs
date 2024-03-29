﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Models
{
    public class BasketProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product ProductRef { get; set; }
        public int Quantity { get; set; }
        public int ShoppingBasketId { get; set; }
        public ShoppingBasket ShoppingBasketRef { get; set; }
    }
}
