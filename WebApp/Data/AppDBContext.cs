using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customization> Customizations { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Addition> Additions { get; set; }
        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Filling> Fillings { get; set; }
        public DbSet<Glaze> Glazes { get; set; }

        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Customization>()
                .HasMany(c => c.OrderDetails)
                .WithOne(od => od.Customization)
                .HasForeignKey(od => od.CustomizationId);

            modelBuilder.Entity<Addition>()
                .HasMany(a => a.Customizations)
                .WithOne(c => c.Addition)
                .HasForeignKey(c => c.AdditionId);

            modelBuilder.Entity<Cake>()
                .HasMany(ca => ca.Customizations)
                .WithOne(cu => cu.Cake)
                .HasForeignKey(c => c.CakeId);

            modelBuilder.Entity<Filling>()
                .HasMany(f => f.Customizations)
                .WithOne(c => c.Filling)
                .HasForeignKey(c => c.FillingId);

            modelBuilder.Entity<Glaze>()
                .HasMany(g => g.Customizations)
                .WithOne(c => c.Glaze)
                .HasForeignKey(c => c.GlazeId);

            modelBuilder.Entity<Size>()
                .HasMany(s => s.Customizations)
                .WithOne(c => c.Size)
                .HasForeignKey(c => c.SizeId);


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

            modelBuilder.Entity<Size>().HasData(
                new Size()
                {
                    SizeId = 1,
                    Diameter = 20
                },
                new Size()
                {
                    SizeId = 2,
                    Diameter = 30
                },
                new Size()
                {
                    SizeId = 3,
                    Diameter = 45
                }
            );

            modelBuilder.Entity<Cake>().HasData(
                new Cake()
                {
                    CakeId = 1,
                    CakeName = "Śmietankowe",
                    CakeColor = "#FFFF99"
                },
                new Cake()
                { 
                    CakeId = 2,
                    CakeName = "Waniliowe",
                    CakeColor = "#FDE456"
                },
                new Cake()
                {
                    CakeId = 3,
                    CakeName = "Czekoladowe",
                    CakeColor = "#AC7A33"
                }
            );

            modelBuilder.Entity<Filling>().HasData(
                new Filling()
                {
                    FillingId = 1,
                    FillingName = "Kremowe",
                    FillingColor = "#FFFDD0"
                },
                new Filling()
                {
                    FillingId = 2,
                    FillingName = "Czekoladowe",
                    FillingColor = "#7B3F00"
                },
                new Filling()
                {
                    FillingId = 3,
                    FillingName = "Truskawkowe",
                    FillingColor = "#CF2942"
                },
                new Filling()
                {
                    FillingId = 4,
                    FillingName = "Malinowe",
                    FillingColor = "#DC143C"
                }
            );

            modelBuilder.Entity<Glaze>().HasData(
                new Glaze()
                {
                    GlazeId = 1,
                    GlazeName = "Śmietankowa",
                    GlazeColor = "#FFFFF0"
                },
                new Glaze()
                {
                    GlazeId = 2,
                    GlazeName = "Czekoladowa",
                    GlazeColor = "#7B3F00"
                },
                new Glaze()
                {
                    GlazeId = 3,
                    GlazeName = "Truskawkowa",
                    GlazeColor = "#F5ACCB"
                }
            );

            modelBuilder.Entity<Addition>().HasData(
                new Addition()
                {
                    AdditionId = 1,
                    AdditionName = "Owoce"
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1,
                    CustomerEmail = "piotrek3201@onet.pl",
                    CustomerName = "Piotr Kałuziński",
                    CustomerPhone = "+48501171851",
                    CustomerAddress = "Aleja Jana Pawła II 21/37",
                    CustomerPostalCode = "00-213",
                    Date = DateTime.Now,
                    DeliveryDate = DateTime.Now.AddDays(2),
                    OrderValue = 50M
                },
                new Order
                {
                    OrderId = 2,
                    CustomerEmail = "jan.kowalski@gmail.com",
                    CustomerName = "Jan Kowalski",
                    CustomerPhone = "+48501355704",
                    CustomerAddress = "Długa 10",
                    CustomerPostalCode = "02-137",
                    Date = DateTime.Now,
                    DeliveryDate= DateTime.Now.AddDays(4),
                    OrderValue = 20M
                }
            );

            modelBuilder.Entity<Customization>().HasData(
                new Customization()
                {
                    CustomizationId = 1,
                    //OrderDetailId = 1,
                    SizeId = 3,
                    GlazeId = 1,
                    FillingId = 2,
                    CakeId = 1,
                    AdditionId = 1,
                    Text = "100 lat!"
                }
            );

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    OrderDetailId = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 0.5,
                    Price = 8.5M,
                    CustomizationId = 1
                },
                new OrderDetail
                {
                    OrderDetailId = 2,
                    OrderId = 1,
                    ProductId = 3,
                    Quantity = 2,
                    Price = 40M,
                    
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

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}
