using System;

namespace ProductManagement.API.DTOs
{
    public class Product
    {
        public int Code { get; set; }
       
        public string Description { get; set; }
        
        public DateTime ManufacturingDate { get; set; }
      
        public DateTime ValidityDate { get; set; }
       
        public Provider Provider { get; set; }
    }
}
