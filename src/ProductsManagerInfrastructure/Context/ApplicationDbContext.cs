using Microsoft.EntityFrameworkCore;
using ProductsManagement.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsManagerInfrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
