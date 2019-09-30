using SH_SWAT.Usimba.EventOrientedModule.CQRS;

namespace SH_SWAT.Usimba.EventOrientedModule.Contexts
{
    public class GameContext : AppContext
    {

        public GameContext(IServiceLocator serviceLocator, IMessageBus messageBus) 
            : base(serviceLocator, messageBus)
        {
        }
    }
}