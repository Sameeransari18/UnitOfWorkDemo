using UnitOfWorkDemo.Interfaces;
using UnitOfWorkDemo.IServices;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateCustomer(CustomerDetail customer)
        {
            if (customer != null)
            {
                await _unitOfWork.Customers.Add(customer);

                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            if (id > 0)
            {
                var customer = await _unitOfWork.Customers.GetById(id);
                if (customer != null)
                {
                    _unitOfWork.Customers.Delete(customer);

                    var result = _unitOfWork.Save();
                    if (result > 0) 
                        return true;
                    else 
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<CustomerDetail>> GetAllCustomer()
        {
            var customers = await _unitOfWork.Customers.GetAll();
            return customers;
        }

        public async Task<CustomerDetail> GetCustomerById(int id)
        {
            if (id > 0)
            {
                var customer = await _unitOfWork.Customers.GetById(id);
                if (customer != null)
                {
                    return customer;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCustomer(CustomerDetail customer)
        {
            if (customer != null)
            {
                var customerDetail = await _unitOfWork.Customers.GetById(customer.Id);
                if (customerDetail != null)
                {
                    if(customer.Name != null) 
                        customerDetail.Name = customer.Name;
                    if (customer.Role != null)
                        customerDetail.Role = customer.Role;

                    _unitOfWork.Customers.Update(customerDetail);

                    var result = _unitOfWork.Save();
                    if (result > 0)
                        return true;
                    else 
                        return false;
                }
            }
            return false;
        }
    }
}
