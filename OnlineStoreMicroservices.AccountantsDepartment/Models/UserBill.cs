using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Models
{
    public class UserBill
    {
        public decimal Total{ get; set; }
        public int Quantity{ get; set; }
    }
}
