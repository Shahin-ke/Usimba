using SH_SWAT.Usimba.Validation.UnaryOperators;

namespace SH_SWAT.Usimba.Validation.BinaryOperators
{
    public class AndValidator : BaseBinaryValidator
    {
        public AndValidator(IValidator leftOperand, IValidator rightOperand) : base(leftOperand, rightOperand) { }

        public override ValidationResult IsValid(object obj, ValidationContext context)
        {
            return
                new BooleanToValidationResult().IsValid(
                    (ValidationResult.Accepted == LeftOperand.IsValid(obj, context)) &&
                    (ValidationResult.Accepted == RightOperand.IsValid(obj, context)), context);
        }
    }
}