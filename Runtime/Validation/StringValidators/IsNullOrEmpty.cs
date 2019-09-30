using SH_SWAT.Usimba.Validation.UnaryOperators;

namespace SH_SWAT.Usimba.Validation.StringValidators
{
    public class IsNullOrEmpty : BaseTypedValidator<string>
    {
        public override ValidationResult IsValid(string obj, ValidationContext context)
        {
            return new BooleanToValidationResult()
                .IsValid(string.IsNullOrEmpty(obj), context);
        }
    }
}