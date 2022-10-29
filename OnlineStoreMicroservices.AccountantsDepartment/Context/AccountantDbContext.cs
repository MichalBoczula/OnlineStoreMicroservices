using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineStoreMicroservices.AccountantsDepartment.Context.Abstract;
using OnlineStoreMicroservices.AccountantsDepartment.Context.Seed;
using OnlineStoreMicroservices.AccountantsDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Context
{
    public class AccountantDbContext : DbContext, IAccountantDbContext
    {
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserBasket> UserBaskets { get; set; }
        public DbSet<UserBill> UserBills { get; set; }

        public AccountantDbContext(DbContextOptions<AccountantDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.CreateProductSeed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await this.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction(IDbContextTransaction Transaction, CancellationToken cancellationToken)
        {
            await Transaction.CommitAsync(cancellationToken);
        }

        public async Task RollbackTransaction(IDbContextTransaction Transaction, CancellationToken cancellationToken)
        {
            await Transaction.RollbackAsync(cancellationToken);
        }
    }
}
