namespace SH_SWAT.Usimba.EventOrientedModule.CQRS.Validators
{
    public class AndValidator<TMessage> : BaseConditionValidator<TMessage> where TMessage : class, IMessage
    {
        private readonly IMessageConditionValidator _leftOp;
        private readonly IMessageConditionValidator _rightOp;

        public AndValidator(IMessageConditionValidator leftOp, IMessageConditionValidator rightOp)
        {
            _leftOp = leftOp;
            _rightOp = rightOp;
        }
        public override ValidationResult Validate(IMessageHandler handler, TMessage message)
        {
            var leftResult = _leftOp.Validate(handler, message);
            var rightResult = _rightOp.Validate(handler, message);

            return ValidationResult.Accepted == leftResult && ValidationResult.Accepted == rightResult
                ? ValidationResult.Accepted
                : ValidationResult.Rejected;
        }
    }
}