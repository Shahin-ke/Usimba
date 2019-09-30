namespace SH_SWAT.Usimba.EventOrientedModule.CQRS
{
    public interface IMessageBus
    {
        void RaiseEvent(IEvent evt);
        void SendCommand(ICommand cmd);

        void Subscribe<TMessageHandler, TMessage>(TMessageHandler handler, IMessageHandlerActionExecutor methodSelector)
            where TMessage : class, IMessage
            where TMessageHandler : class, IMessageHandler<TMessage>;

        void Unsubscribe<TMessageHandler, TMessage>(TMessageHandler handler)
            where TMessage : class, IMessage
            where TMessageHandler : class, IMessageHandler<TMessage>;

        void AddRule(MessageRouteRule rule);
    }
}