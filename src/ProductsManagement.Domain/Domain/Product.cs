using System;

namespace ProductsManagement.Domain.Domain
{
    public class Product
    {       
        public int Id { get; set; }       
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ValidityDate { get; set; } 
        public Provider Provider { get; set; }

    }
}
