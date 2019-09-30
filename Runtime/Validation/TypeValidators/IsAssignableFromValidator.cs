using System;
using SH_SWAT.Usimba.Validation.UnaryOperators;

namespace SH_SWAT.Usimba.Validation.TypeValidators
{
    public class IsAssignableFromValidator : BaseTypedValidator<Type>
    {
        private readonly Type _baseType;

        public IsAssignableFromValidator(Type baseType)
        {
            _baseType = baseType;
        }

        public override ValidationResult IsValid(Type obj, ValidationContext context)
        {
            return new BooleanToValidationResult().IsValid(_baseType.IsAssignableFrom(obj), context);
        }
    }
}