using SH_SWAT.Usimba.EventOrientedModule.CQRS.Validators;
using SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Handlers;
using SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Messages;

namespace SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Validators
{
    public class AlwaysConstResultConditionValidator : BaseConditionValidator<SomeMessageHandler, SomeMessage>
    {
        private readonly ValidationResult _result;

        public AlwaysConstResultConditionValidator(ValidationResult result)
        {
            _result = result;
        }

        public override ValidationResult Validate(SomeMessageHandler handler, SomeMessage message)
        {
            return _result;
        }
    }
}