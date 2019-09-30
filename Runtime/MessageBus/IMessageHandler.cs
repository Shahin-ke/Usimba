namespace SH_SWAT.Usimba.EventOrientedModule.CQRS
{
    public interface IMessageHandler
    {
        int? EntityId { get; }
    }

    public interface IMessageHandler<in TMessage> : IMessageHandler
        where TMessage : IMessage
    {
        void Handle(TMessage message);
    }
}