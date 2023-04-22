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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=DESKTOP-1C1EU5R\\SQLSERVER2019G3;user id=sa;password=P@ssw0rd;Initial catalog=dbNewProduct22Apr2023");
        }
    }
}
