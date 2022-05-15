using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: relationships
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Torty"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Ciasta"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Ciastka"
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Cukierki"
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Lody"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Tort własny",
                    Description = "Sam skomponuj swój wymarzony tort!",
                    Price = 50.0,
                    IsByWeight = false,
                    IsCustomizable = true
                },
                new Product()
                {
                    ProductId = 2,
                    CategoryId = 2,
                    Name = "Brownie",
                    Description = "Pyszne czekoladowe ciasto, lepsze niż we Władysławowie!",
                    Price = 20.0,
                    IsByWeight = false
                }, new Product()
                {
                    ProductId = 3,
                    CategoryId = 4,
                    Name = "Szarlotka",
                    Description = "Klasyczne ciasto ze świeżymi jabłkami",
                    Price = 15.0,
                    IsByWeight = false
                }, new Product()
                {
                    ProductId = 4,
                    CategoryId = 4,
                    Name = "Kukułki",
                    Description = "Kultowe karmelki",
                    Price = 17.0,
                    IsByWeight = true
                }
            );
        }
    }
}
