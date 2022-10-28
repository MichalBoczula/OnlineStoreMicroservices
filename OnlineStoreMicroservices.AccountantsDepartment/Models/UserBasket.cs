using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Models
{
    public class UserBasket
    {
        public int Id { get; set; }
        public List<BasketProduct> BasketProducts { get; set; }
        public UserBill Bill { get; set; }
    }
}
