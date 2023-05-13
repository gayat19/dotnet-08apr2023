using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Models
{
    public class CustomerContext : DbContext
    {
        //public CustomerContext()
        //{
            
        //}
        public CustomerContext(DbContextOptions opts):base(opts)
        {
            
        }
        public DbSet<USer> Users { get; set; }
    }
}
