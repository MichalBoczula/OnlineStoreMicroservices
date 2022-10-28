using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Models
{
    public class UserBasket
    {
        public int Id { get; set; }
        public List<BasketProduct> BasketProducts { get; set; }
    }
}
