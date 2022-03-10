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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product, int providerCode)
        {
            product.Provider = _context.Providers.SingleOrDefault(x => x.Id == providerCode);
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<DataCollection<Product>> GetAllAsync(int page, int take)
        {
            return await _context.Products.Where(x => x.IsActive).Include(p => p.Provider)
                .OrderBy(x => x.Id).GetPagedAsync(page, take);
        }

        public async Task<Product> GetByCodeAsync(int code)
        {
            return await _context.Products.Include(p => p.Provider).SingleOrDefaultAsync(p => p.IsActive && p.Id == code);
        }        

        public async Task<Product> UpdateAsync(Product product)
        {
            Product selectedproduct = await _context.Products.SingleOrDefaultAsync(x => x.Id == product.Id);

            if(selectedproduct != null)
            {
                selectedproduct.Description = product.Description;
                selectedproduct.IsActive = product.IsActive;                
                selectedproduct.ManufacturingDate = product.ManufacturingDate;
                selectedproduct.ValidityDate = product.ValidityDate;                                         
            }
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
