namespace SH_SWAT.Usimba.Validation
{
    public interface ITypedValidator<in T> : IValidator
    {
        ValidationResult IsValid(T obj, ValidationContext context);
    }
}