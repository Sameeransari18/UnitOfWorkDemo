using UnitOfWorkDemo.Interfaces;
using UnitOfWorkDemo.IServices;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Services
{
    // Implementation for the Product Service CRUD
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateProduct(ProductDetail productDetails)
        {
            if (productDetails != null)
            {
                await _unitOfWork.Products.Add(productDetails);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;

            }
            return false;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId != null)
            {
                var product = await _unitOfWork.Products.GetById(productId);

                if (product != null)
                {
                    _unitOfWork.Products.Delete(product);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ProductDetail>> GetAllProducts()
        {
            var productDetailsList = await _unitOfWork.Products.GetAll();
            return productDetailsList;
        }

        public async Task<ProductDetail> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var productDetail = await _unitOfWork.Products.GetById(productId);
                if (productDetail != null)
                {
                    return productDetail;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(ProductDetail productDetails)
        {
            if (productDetails != null)
            {
                var product = await _unitOfWork.Products.GetById(productDetails.Id);
                if (product != null)
                {
                    product.Name = productDetails.Name;
                    product.Description = productDetails.Description;
                    product.Price = productDetails.Price;
                    product.Stock = productDetails.Stock;

                    _unitOfWork.Products.Update(product);

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
