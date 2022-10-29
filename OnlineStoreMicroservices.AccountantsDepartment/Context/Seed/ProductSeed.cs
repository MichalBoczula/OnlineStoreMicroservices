using Microsoft.EntityFrameworkCore;

namespace OnlineStoreMicroservices.AccountantsDepartment.Context.Seed
{
    public static class ProductSeed
    {
        public static void CreateProductSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Product>()
                .HasData(new Models.Product
                {
                    Id = 1,
                    Name = "Boots one",
                    Price = 100m
                });

            modelBuilder.Entity<Models.Product>()
                .HasData(new Models.Product
                {
                    Id = 2,
                    Name = "Boots two",
                    Price = 150m
                });

            modelBuilder.Entity<Models.Product>()
                .HasData(new Models.Product
                {
                    Id = 3,
                    Name = "Boots three",
                    Price = 200m
                });
        }
    }
}
