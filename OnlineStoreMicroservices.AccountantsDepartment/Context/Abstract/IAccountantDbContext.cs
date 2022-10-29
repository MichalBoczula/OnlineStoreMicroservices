using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineStoreMicroservices.AccountantsDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Context.Abstract
{
    public interface IAccountantDbContext
    {
        DbSet<BasketProduct> BasketProducts { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<UserBasket> UserBaskets { get; set; }
        DbSet<UserBill> UserBills { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> BeginTransaction();
        Task CommitTransaction(IDbContextTransaction Transaction, CancellationToken cancellationToken);
        Task RollbackTransaction(IDbContextTransaction Transaction, CancellationToken cancellationToken);
    }
}
