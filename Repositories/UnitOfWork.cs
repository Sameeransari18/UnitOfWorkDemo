using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Interfaces;
using UnitOfWorkDemo.IRepositories;

namespace UnitOfWorkDemo.Repositories
{
    // Implemenation the UnitOfWork for the DbContext CRUD operations
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public IProductRepository Products { get; }
        public ICustomerRepository Customers { get; set; }

        public UnitOfWork(DbContextClass dbContext, IProductRepository productRepository,
            ICustomerRepository customerRepository)
        {
            _dbContext = dbContext;
            Products = productRepository;
            Customers = customerRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
