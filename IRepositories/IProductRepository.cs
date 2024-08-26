using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Interfaces
{
    // Injecting the created Generic-interface
    public interface IProductRepository: IGenericRepository<ProductDetail>
    {

    }
}
