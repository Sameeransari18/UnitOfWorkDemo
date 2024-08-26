using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Interfaces;
using UnitOfWorkDemo.Models;
using UnitOfWorkDemo.Services;

namespace UnitOfWorkDemo.Repositories
{
    // Injecting the DbContext call as Generic along with the CRUD operation 
    public class ProductRepository : GenericRepository<ProductDetail>, IProductRepository
    {
        public ProductRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
