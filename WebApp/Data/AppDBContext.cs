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
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: relationships
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product)
                .HasForeignKey(od => od.ProductId);

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
                    Price = 50M,
                    IsByWeight = false,
                    IsCustomizable = true
                },
                new Product()
                {
                    ProductId = 2,
                    CategoryId = 2,
                    Name = "Brownie",
                    Description = "Pyszne czekoladowe ciasto, lepsze niż we Władysławowie!",
                    Price = 20M,
                    IsByWeight = false
                }, new Product()
                {
                    ProductId = 3,
                    CategoryId = 4,
                    Name = "Szarlotka",
                    Description = "Klasyczne ciasto ze świeżymi jabłkami",
                    Price = 15M,
                    IsByWeight = false
                }, new Product()
                {
                    ProductId = 4,
                    CategoryId = 4,
                    Name = "Kukułki",
                    Description = "Kultowe karmelki",
                    Price = 17M,
                    IsByWeight = true
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1,
                    CustomerEmail = "piotrek3201@onet.pl",
                    CustomerName = "Piotr Kałuziński",
                    CustomerPhone = "+48501171851",
                    Date = DateTime.Now,
                    OrderValue = 50M
                },
                new Order
                {
                    OrderId = 2,
                    CustomerEmail = "jan.kowalski@gmail.com",
                    CustomerName = "Jan Kowalski",
                    CustomerPhone = "+48501355704",
                    Date = DateTime.Now,
                    OrderValue = 20M
                }
            );

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    OrderDetailId = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 0.5,
                    Price = 8.5M
                },
                new OrderDetail
                {
                    OrderDetailId = 2,
                    OrderId = 1,
                    ProductId = 3,
                    Quantity = 2,
                    Price = 40M
                },
                new OrderDetail
                {
                    OrderDetailId = 3,
                    OrderId = 2,
                    ProductId = 4,
                    Quantity = 1,
                    Price = 15M
                },
                new OrderDetail
                {
                    OrderDetailId = 4,
                    OrderId = 2,
                    ProductId = 2,
                    Quantity = 0.25,
                    Price = 4.75M
                }
            );
        }
    }
}
