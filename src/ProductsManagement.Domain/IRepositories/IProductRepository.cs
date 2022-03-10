using ProductsManagement.Domain.Common;
using ProductsManagement.Domain.Domain;
using System.Threading.Tasks;

namespace ProductsManagement.Domain.IRepositories
{
    public interface IProductRepository
    {
        Task<DataCollection<Product>> GetAllAsync(int page, int take);

        Task<Product> GetByCodeAsync(int code);

        Task<Product> CreateAsync(Product product, int providerCode);

        Task<Product> UpdateAsync(Product product);
    }
}
