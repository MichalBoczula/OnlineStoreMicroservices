using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Models
{
    public class UserBill
    {
        public int Id { get; set; }
        public decimal Total{ get; set; }
        public int Quantity{ get; set; }
        public UserBasket UserBasketRef { get; set; }
        public int UserBasketId { get; set; }
    }
}
