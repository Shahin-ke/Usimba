using SH_SWAT.Usimba.EventOrientedModule.CQRS;

namespace SH_SWAT.Usimba.EventOrientedModule
{
    public class EventOrientedObject
    {
        public string Id { get; }

        protected readonly IMessageBus MessageBus;
        private readonly IEventList _eventList;

        public EventOrientedObject(IMessageBus messageBus)
        {
            MessageBus = messageBus;
            _eventList = new EventList(messageBus, this);
        }

        protected void ApplyChange(IEvent evt)
        {
            ApplyChange(evt, true);
        }

        private void ApplyChange(IEvent evt, bool isNew)
        {
            _eventList.ApplyChange(evt, isNew);
        }
    }
}