using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.IRepositories;
using UnitOfWorkDemo.Models;
using UnitOfWorkDemo.Services;

namespace UnitOfWorkDemo.Repositories
{
    public class CustomerRepository : GenericRepository<CustomerDetail>, ICustomerRepository
    {
        public CustomerRepository(DbContextClass dbContext) : base(dbContext)
        {
        }
    }
}
