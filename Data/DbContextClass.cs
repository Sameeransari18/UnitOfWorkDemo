using Microsoft.EntityFrameworkCore;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<ProductDetail> Products { get; set; }
        public DbSet<CustomerDetail> Customers { get; set; }
    }
}
