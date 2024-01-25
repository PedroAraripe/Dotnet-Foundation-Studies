using OrdersApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrdersApi.CustomValidators
{
    public class MinimumProductValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            List<Product>? products = value as List<Product>;
            if(products == null || products.Count == 0)
            {
                return new ValidationResult($"{validationContext.DisplayName} length minimum is of 1.");
            }
            return ValidationResult.Success;
        }
    }
}
