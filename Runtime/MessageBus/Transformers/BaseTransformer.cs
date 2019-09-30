using System;

namespace SH_SWAT.Usimba.EventOrientedModule.CQRS.Transformers
{
    public abstract class BaseTransformer : IMessageTransformer
    {
        public Type InputType { get; }
        public Type OutputType { get; }

        protected BaseTransformer(Type inputType, Type outputType)
        {
            InputType = inputType;
            OutputType = outputType;
        }

        public abstract IMessage Transform(IMessage message);
    }

    public abstract class BaseTransformer<TIn, TOut> : IMessageTransformer<TIn, TOut>
        where TIn : class, IMessage
        where TOut : class, IMessage
    {
        public Type InputType { get; }
        public Type OutputType { get; }

        protected BaseTransformer()
        {
            InputType = typeof(TIn);
            OutputType = typeof(TOut);
        }

        public abstract TOut Transform(TIn message);

        public IMessage Transform(IMessage message)
        {
            return Transform((TIn)message);
        }
    }
}