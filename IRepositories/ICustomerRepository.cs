using UnitOfWorkDemo.Interfaces;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.IRepositories
{
    public interface ICustomerRepository: IGenericRepository<CustomerDetail>
    {
    }
}
