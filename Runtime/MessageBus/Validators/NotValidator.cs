namespace SH_SWAT.Usimba.EventOrientedModule.CQRS.Validators
{
    public class NotValidator<TMessage> : BaseConditionValidator<TMessage> where TMessage : class, IMessage
    {
        private readonly IMessageConditionValidator _op;

        public NotValidator(IMessageConditionValidator op)
        {
            _op = op;
        }
        public override ValidationResult Validate(IMessageHandler handler, TMessage message)
        {
            return ValidationResult.Accepted == _op.Validate(handler, message)
                ? ValidationResult.Rejected
                : ValidationResult.Accepted;
        }
    }
}