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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: relationships

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
        }
    }
}
