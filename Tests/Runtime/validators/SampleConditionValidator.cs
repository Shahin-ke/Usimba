using SH_SWAT.Usimba.EventOrientedModule.CQRS.Validators;
using SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Handlers;
using SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Messages;

namespace SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Validators
{
    public class SampleConditionValidator : BaseConditionValidator<SomeMessageHandler, SomeMessage>
    {
        private readonly string _handlerName;
        private readonly string _messageString;

        public SampleConditionValidator(string handlerName, string messageString)
        {
            _handlerName = handlerName;
            _messageString = messageString;
        }

        public override ValidationResult Validate(SomeMessageHandler handler, SomeMessage message)
        {
            return handler.Name == _handlerName && message.Message == _messageString
                ? ValidationResult.Accepted
                : ValidationResult.Rejected;
        }
    }
}