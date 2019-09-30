namespace SH_SWAT.Usimba.Validation
{
    public interface IValidator
    {
        ValidationResult IsValid(object obj, ValidationContext context);
    }
}