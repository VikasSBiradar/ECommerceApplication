using ECommerceApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.CustomValidators
{
    public class ProductListValidatorAttribute : ValidationAttribute
    {
        public string DefaultMessage { get; set; } = "Order should have at least one product";

        public ProductListValidatorAttribute() { }// Creating constructor

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) { 
                List<Product> products = (List<Product>)value;

                if (products.Count == 0)
                {

                    return new ValidationResult(DefaultMessage, new string[] { nameof(validationContext.MemberName) });
                }
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
