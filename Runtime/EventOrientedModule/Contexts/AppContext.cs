using SH_SWAT.Usimba.EventOrientedModule.CQRS;

namespace SH_SWAT.Usimba.EventOrientedModule.Contexts
{
    public class AppContext : Context
    {
        public IServiceLocator ServiceLocator { get; }
        public IMessageBus MessageBus { get; }

        public AppContext(IServiceLocator serviceLocator, IMessageBus messageBus)
        {
            ServiceLocator = serviceLocator;
            MessageBus = messageBus;
        }
    }
}