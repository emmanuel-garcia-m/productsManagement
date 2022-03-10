using System;

namespace ProductsManagement.Domain.Domain
{
    public class Provider
    {          
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
