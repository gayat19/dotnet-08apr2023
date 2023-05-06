using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Models
{
    public class ShopContext :DbContext
    {
        public ShopContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                 new Product { Id = 101, Name = "Pencil", Price = 5.0f, Quantity = 10 },
                     new Product { Id = 102, Name = "Pen", Price = 15.75f, Quantity = 3 },
                    new Product { Id = 103, Name = "Eraser", Price = 3.5f, Quantity = 5 }
                );
        }
    }
}
