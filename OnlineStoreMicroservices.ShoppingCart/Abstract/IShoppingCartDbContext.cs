using Microsoft.EntityFrameworkCore;
using OnlineStoreMicroservices.ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Abstract
{
    public interface IShoppingCartDbContext
    {
        DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<BasketProduct> BasketProducts { get; set; }
    }
}
