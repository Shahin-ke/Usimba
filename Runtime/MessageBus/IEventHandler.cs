namespace SH_SWAT.Usimba.EventOrientedModule.CQRS
{
    public interface IEventHandler<in TEvent> : IMessageHandler<TEvent>
        where TEvent : IEvent
    { 
        new void Handle(TEvent evt);
    }
}