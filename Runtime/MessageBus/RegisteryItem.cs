using System;
using SH_SWAT.Usimba.EventOrientedModule.CQRS;

namespace SH_SWAT.Usimba.MessageBus
{
    public class RegisteryItem
    {
        public Type HandlerType { get; }
        public Type MessageType { get; }
        public WeakReference<dynamic> Handler { get; }
        public IMessageHandlerActionExecutor HandlerMethodSelector { get; }

        public RegisteryItem(Type messageType, object handler, IMessageHandlerActionExecutor handlerMethodSelector)
        {
            HandlerType = handler.GetType();
            MessageType = messageType;
            Handler = new WeakReference<object>(handler, false);
            HandlerMethodSelector = handlerMethodSelector;
        }
    }
}