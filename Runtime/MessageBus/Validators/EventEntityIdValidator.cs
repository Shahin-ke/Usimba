using UnityEngine;

namespace SH_SWAT.Usimba.EventOrientedModule.CQRS.Validators
{
    public class EventEntityIdValidator<TMessage> : BaseConditionValidator<TMessage> where TMessage : class, IMessage, IEvent
    {
        private readonly GameObject _predictedId;

        public EventEntityIdValidator(GameObject predictedId)
        {
            _predictedId = predictedId;
        }
        public override ValidationResult Validate(IMessageHandler handler, TMessage message)
        {
            return message.EventSender == _predictedId ? ValidationResult.Accepted : ValidationResult.Rejected;
        }
    }
}