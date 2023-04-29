using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingEFApp
{
    public class ShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=DESKTOP-1C1EU5R\\SQLSERVER2019G3;user id=sa;password=P@ssw0rd;Initial catalog=dbShopSRF");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.ProdNo);
            modelBuilder.Entity<Category>()
                            .HasMany(p => p.Products)
                            .WithOne(p => p.Category)
                            .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sodas" },
                new Category { Id = 2, Name = "Quick Food" }
                );
                
        }
    }
}
