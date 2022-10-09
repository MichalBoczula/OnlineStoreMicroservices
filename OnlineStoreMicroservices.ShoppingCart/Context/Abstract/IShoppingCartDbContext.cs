using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineStoreMicroservices.ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Context.Abstract
{
    public interface IShoppingCartDbContext
    {
        DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<BasketProduct> BasketProducts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> BeginTransaction();
        Task CommitTransaction(IDbContextTransaction Transaction, CancellationToken cancellationToken);
        Task RollbackTransaction(IDbContextTransaction Transaction, CancellationToken cancellationToken);
    }
}
