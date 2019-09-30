namespace SH_SWAT.Usimba.Validation.General
{
    public class NotNull : IValidator
    {
        public ValidationResult IsValid(object obj, ValidationContext context)
        {
            return null != obj ? ValidationResult.Accepted : ValidationResult.Rejected;
        }
    }
}