using SH_SWAT.Usimba.EventOrientedModule.CQRS.Transformers;
using SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Messages;

namespace SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Transformers
{
    public class SampleTransformer :
            BaseTransformer<SomeOtherMessage, SomeMessage>
        //IMessageTransformer<SomeMessage, SomeOtherMessage>
    {
        public override SomeMessage Transform(SomeOtherMessage message)
        {
            return new SomeMessage(message.Message, message.EventSender, message.UtcOccurTime);
        }
    }
}