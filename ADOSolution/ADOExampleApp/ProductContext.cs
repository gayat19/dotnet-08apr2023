using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOExampleApp
{
    public class ProductContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=DESKTOP-1C1EU5R\\SQLSERVER2019G3;user id=sa;password=P@ssw0rd;Initial catalog=dbNewProduct29Apr2023");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasKey(d => d.DeptId);
            modelBuilder.Entity<Department>().HasData(
                new Department { DeptId=101,Name="HR"},
                new Department { DeptId = 102, Name = "Ops" }
                );
            modelBuilder.Entity<Department>()
                                .HasMany(d => d.Employees)
                                .WithOne(d=>d.Department)
                                .HasForeignKey(k=>k.Dep_Id)
                                .HasConstraintName("fk_Department")
                                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1000, Name = "Ramu", Salary = 124434, Dep_Id = 101 }
                );
        }
    }
}
