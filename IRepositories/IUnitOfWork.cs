using UnitOfWorkDemo.IRepositories;

namespace UnitOfWorkDemo.Interfaces
{
    // Implementing the UnitOfWork for CRUD operations
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICustomerRepository Customers { get; }
        int Save();
    }
}
