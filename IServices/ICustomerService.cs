using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.IServices
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomer(CustomerDetail customer);
        Task<IEnumerable<CustomerDetail>> GetAllCustomer();
        Task<CustomerDetail> GetCustomerById(int id);
        Task<bool> UpdateCustomer(CustomerDetail customer);
        Task<bool> DeleteCustomer(int id);
    }
}
