using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Models
{
    public class BasketProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product ProductRef { get; set; }
        public int Quantity { get; set; }
        public int UserBasketId { get; set; }
        public UserBasket UserBasketRef { get; set; }
    }
}
