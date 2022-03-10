using ProductManagement.API.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.API.CustomValidations
{
    public class CustomManufacturingDate : ValidationAttribute
    {   
        public string GetErrorMessage() => $"La fecha de fabricación no puede ser mayor o igual la fecha de vencimiento";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ProductCreateOrEditModel product = (ProductCreateOrEditModel)validationContext.ObjectInstance;
            DateTime ManufacturingDate = Convert.ToDateTime(value);

            if (ManufacturingDate.Date >= product.ValidityDate.Date )
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
