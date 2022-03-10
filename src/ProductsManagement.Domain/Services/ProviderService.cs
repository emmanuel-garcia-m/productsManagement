using ProductsManagement.Domain.Common;
using ProductsManagement.Domain.Contracts;
using ProductsManagement.Domain.Domain;
using ProductsManagement.Domain.IRepositories;
using System.Threading.Tasks;

namespace ProductsManagement.Domain.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<Provider> CreateAsync(Provider provider)
        {
            return await _providerRepository.CreateAsync(provider);
        }

        public async Task<DataCollection<Provider>> GetAllAsync(int page, int take)
        {
            return await _providerRepository.GetAllAsync(page, take);
        }

        public async Task<Provider> GetByCodeAsync(int code)
        {
            return await _providerRepository.GetByCodeAsync(code);
        }
    }
}
