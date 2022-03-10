using ProductsManagement.Domain.Common;
using ProductsManagement.Domain.Domain;
using System.Threading.Tasks;

namespace ProductsManagement.Domain.Contracts
{
    public interface IProductService
    {
        Task<DataCollection<Product>> GetAllAsync(int page, int take);

        Task<Product> GetByCodeAsync(int code);

        Task<Product> CreateAsync(Product product, int providerCode);

        Task UpdateAsync(Product product);

        Task<Product> DeleteAsync(int code);
    }
}
