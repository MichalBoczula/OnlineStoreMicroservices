using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Models
{
    public class ShoppingBasket
    {
        public int Id { get; set; }
        public List<BasketProduct> BasketProducts { get; set; }
        public string? DiscountCouponId { get; set; }
        public decimal Total { get; set; }
    }
}
