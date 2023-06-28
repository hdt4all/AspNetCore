using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ModelValidations.Models
{
    public class Person //: IValidatableObject //perform validation on more than one properties. If you inherit from IValidatableObject, the validation will be bound to specific Model only. IValidatableObject.Validate method will execute ONLY AFTER all property level validation of the Model succeed. s
    {
        [Required(ErrorMessage = "{0} apo vadil")]
        [Display(Name = "Tamaru Naam")]
        [StringLength(40, MinimumLength = 5, ErrorMessage ="{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]$", ErrorMessage = "Invalid {0}")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage ="{0} is invalid")]
        public string? Email { get; set; }

        [Phone(ErrorMessage ="{0} is invalid")]
        [Display(Name="Tamaro Phone")]
        public string? Phone { get; set; }

        public string? Password { get; set; }

        //[BindNever] - to opt out of binding for specific property to the model
        public string? ConfirmPassword { get; set; }

        [Range(10,20, ErrorMessage ="{0} should be between {1} and {2}")]
        public double? Price { get; set; }

        [CustomValidator(2005, ErrorMessage ="Year of birth cannot be lower than {0}")]
        public DateTime DateofBirth { get; set; }

        public DateTime FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage="'From Date' should be older than or equal to 'To Date'")]
        public DateTime ToDate { get; set; }

        public override string ToString()
        {
            return $"Person Object - {Name} {Email} {Phone} {Password} {ConfirmPassword} {Price}";
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
