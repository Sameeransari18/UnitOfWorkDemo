using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.IServices
{
    // Interface for Product CRUD operation
    public interface IProductService
    {
        Task<bool> CreateProduct(ProductDetail productDetails);

        Task<IEnumerable<ProductDetail>> GetAllProducts();

        Task<ProductDetail> GetProductById(int productId);

        Task<bool> UpdateProduct(ProductDetail productDetails);

        Task<bool> DeleteProduct(int productId);
    }
}
