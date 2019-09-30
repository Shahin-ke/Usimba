using System;
using SH_SWAT.Usimba.EventOrientedModule.CQRS;

namespace SH_SWAT.Usimba.MessageBus
{
    public class SubscriptionRegisteryItem
    {
        public Type MessagehandlerType;
        public Type MessageType;
        public IMessageHandler Handler;
        public IActionExecutor MethodInfo;
        public MessageRouteRule Route;

        public IDisposable Subscription;
    }
}