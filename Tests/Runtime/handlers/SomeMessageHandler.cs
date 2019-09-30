using System.Collections.Generic;
using System.Linq;
using SH_SWAT.Usimba.EventOrientedModule.CQRS;
using SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Messages;

namespace SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Handlers
{
    public class SomeMessageHandler : IMessageHandler<SomeMessage>
    {
        public int? EntityId { get; }
        public readonly string Name;
        private Queue<SomeMessage> _handledMessages;
        public IReadOnlyList<SomeMessage> HandledMessages => _handledMessages.ToList();

        public int HandleCallCount => _handledMessages.Count;

        public SomeMessageHandler(string name)
        {
            Name = name;
            _handledMessages = new Queue<SomeMessage>();
        }
        
        public void Handle(SomeMessage message)
        {
            _handledMessages.Enqueue(message);
        }
    }
}