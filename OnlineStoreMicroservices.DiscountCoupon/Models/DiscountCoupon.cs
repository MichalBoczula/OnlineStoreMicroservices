using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Models
{
    public class DiscountCoupon
    {
        public int Id { get; set; }
        public string IntegrationId { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public bool IsActual { get; set; }
    }
}
