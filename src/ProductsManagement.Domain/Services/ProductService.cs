using ProductsManagement.Domain.Common;
using ProductsManagement.Domain.Contracts;
using ProductsManagement.Domain.Domain;
using ProductsManagement.Domain.IRepositories;
using System.Threading.Tasks;

namespace ProductsManagement.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
         

        public async Task<DataCollection<Product>> GetAllAsync(int page, int take)
        {
           return await _productRepository.GetAllAsync(page, take);
        }

        public async Task<Product> GetByCodeAsync(int code)
        {
            return await _productRepository.GetByCodeAsync(code);
        }

        public Task UpdateAsync(Product product)
        {
            return _productRepository.UpdateAsync(product);
        }

        public async Task<Product> CreateAsync(Product product, int providerCode)
        {          
            product.IsActive = true;
            return await _productRepository.CreateAsync(product, providerCode);            
        }

        public async Task<Product> DeleteAsync(int code)
        {
            Product product = await _productRepository.GetByCodeAsync(code);
            product.IsActive = false;
            return await _productRepository.UpdateAsync(product);
        }
    }
}
