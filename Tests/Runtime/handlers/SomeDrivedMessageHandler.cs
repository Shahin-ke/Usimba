using System.Collections.Generic;
using System.Linq;
using SH_SWAT.Usimba.EventOrientedModule.CQRS;
using SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Messages;

namespace SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Handlers
{
    internal class SomeDrivedMessageHandler : IMessageHandler<SomeDrivedMessage>
    {
        public readonly string Name;
        private Queue<SomeDrivedMessage> _handledMessages;
        public IReadOnlyList<SomeDrivedMessage> HandledMessages => _handledMessages.ToList();
        public int? EntityId => null;

        public int HandleCallCount => _handledMessages.Count;

        public SomeDrivedMessageHandler(string name)
        {
            Name = name;
            _handledMessages = new Queue<SomeDrivedMessage>();
        }

        public void Handle(SomeDrivedMessage message)
        {
            _handledMessages.Enqueue(message);
        }
    }
}