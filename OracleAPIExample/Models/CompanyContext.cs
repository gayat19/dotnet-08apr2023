using Microsoft.EntityFrameworkCore;

namespace OracleAPIExample.Models
{
    public class CompanyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=DESKTOP-1C1EU5R)(PORT=1521)));user id=sysdba;Password=P@ssw0rd");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
