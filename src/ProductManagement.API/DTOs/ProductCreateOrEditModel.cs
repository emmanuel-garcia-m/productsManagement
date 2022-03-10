using ProductManagement.API.CustomValidations;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.API.DTOs
{
    public class ProductCreateOrEditModel
    {  
        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomManufacturingDate]
        public DateTime ManufacturingDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ValidityDate { get; set; }
        [Required]
        public int ProviderCode { get; set; }       
    }
}
