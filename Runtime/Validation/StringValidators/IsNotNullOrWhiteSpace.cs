using SH_SWAT.Usimba.Validation.UnaryOperators;

namespace SH_SWAT.Usimba.Validation.StringValidators
{
    public class IsNotNullOrWhiteSpace : BaseTypedValidator<string>
    {
        public override ValidationResult IsValid(string obj, ValidationContext context)
        {
            return new BooleanToValidationResult()
                .IsValid(string.IsNullOrWhiteSpace(obj), context);
        }
    }
}