using System.ComponentModel.DataAnnotations;

namespace OrdersApi.CustomValidators
{
    public class FinalCartPriceValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult($"{validationContext.DisplayName} can't be blank.");
            }

            return ValidationResult.Success;
        }
    }
}
