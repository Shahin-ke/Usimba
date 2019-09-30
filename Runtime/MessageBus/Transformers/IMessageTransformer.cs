using System;

namespace SH_SWAT.Usimba.EventOrientedModule.CQRS.Transformers
{
    public interface IMessageTransformer
    {
        Type InputType { get; }
        Type OutputType { get; }
        IMessage Transform(IMessage message);
    }

    public interface IMessageTransformer<in TIn, out TOut> : IMessageTransformer
        where TIn : class, IMessage
        where TOut : class, IMessage
    {
        TOut Transform(TIn message);
    }
}