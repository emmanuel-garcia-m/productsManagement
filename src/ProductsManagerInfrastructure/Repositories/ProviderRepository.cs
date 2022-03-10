using Microsoft.EntityFrameworkCore;
using ProductsManagement.Domain.Common;
using ProductsManagement.Domain.Domain;
using ProductsManagement.Domain.IRepositories;
using ProductsManagerInfrastructure.Common;
using ProductsManagerInfrastructure.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsManagerInfrastructure.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _context;

        public ProviderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Provider> CreateAsync(Provider provider)
        {
            await _context.Providers.AddAsync(provider);
            await _context.SaveChangesAsync();
            return provider;
        }

        public async Task<DataCollection<Provider>> GetAllAsync(int page, int take)
        {
            return await _context.Providers
                .OrderBy(x => x.Id).GetPagedAsync(page, take);
        }

        public async Task<Provider> GetByCodeAsync(int code)
        {
            return await _context.Providers.SingleOrDefaultAsync(p => p.Id == code);
        }
    }
}
