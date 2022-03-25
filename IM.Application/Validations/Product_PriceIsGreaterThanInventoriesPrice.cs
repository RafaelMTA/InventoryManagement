using IM.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IM.Application.Validations
{
    public class Product_PriceIsGreaterThanInventoriesPrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;
            if(product != null)
            {
                if (!product.ValidatePricing()) return new ValidationResult("Product price must be greater than inventories prices");
            }
            return base.IsValid(value, validationContext);
        }
    }
}
