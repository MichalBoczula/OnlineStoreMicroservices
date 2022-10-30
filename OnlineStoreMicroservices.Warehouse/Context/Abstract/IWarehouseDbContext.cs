using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineStoreMicroservices.Warehouse.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Context.Abstract
{
    public interface IWarehouseDbContext
    {
        DbSet<BasketProduct> BasketProducts { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<UserBasket> UserBaskets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> BeginTransaction();
        Task CommitTransaction(IDbContextTransaction Transaction, CancellationToken cancellationToken);
        Task RollbackTransaction(IDbContextTransaction Transaction, CancellationToken cancellationToken);
    }
}
