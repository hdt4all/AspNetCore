using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidations
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string FromDate { get; set; }

        public DateRangeValidatorAttribute(string fromDate) { FromDate = fromDate; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime to_date = Convert.ToDateTime(value);
                PropertyInfo? from_date_property = validationContext.ObjectType.GetProperty(FromDate);
                DateTime from_Date = Convert.ToDateTime(from_date_property.GetValue(validationContext.ObjectInstance));

                if (from_Date > to_date)
                {
                    return new ValidationResult(ErrorMessage, new string[] { FromDate, validationContext.MemberName });
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
