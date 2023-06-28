using System.ComponentModel.DataAnnotations;

namespace ModelValidations
{
    public class CustomValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public CustomValidatorAttribute()
        {

        }

        public CustomValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year < MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage, MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }

            return null;
        }
    }
}
