using ProductsManagement.Domain.Common;
using ProductsManagement.Domain.Domain;
using System.Threading.Tasks;

namespace ProductsManagement.Domain.Contracts
{
    public interface IProviderService
    {
        Task<DataCollection<Provider>> GetAllAsync(int page, int take);

        Task<Provider> GetByCodeAsync(int code);

        Task<Provider> CreateAsync(Provider provider);
    }
}
