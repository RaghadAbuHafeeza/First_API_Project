using API_Products.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Products.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                 new Product { Id = 1, Name = "Laptop", Description = "This is Laptop" },
                 new Product { Id = 2, Name = "Desktop", Description = "This is Desktop" },
                 new Product { Id = 3, Name = "Printer", Description = "This is Printer" },
                 new Product { Id = 4, Name = "HeadPhone", Description = "This is HeadPhone" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
