using System;
using SH_SWAT.Usimba.EventOrientedModule.CQRS.Transformers;
using SH_SWAT.Usimba.EventOrientedModule.CQRS.Validators;

namespace SH_SWAT.Usimba.EventOrientedModule.CQRS
{
    public class MessageRouteRule
    {
        public string Name { get; }
        public Type MessageType { get; }
        public Type HandlerType { get; }

        public IMessageConditionValidator PreCondition { get; }
        public IMessageTransformer Transformer { get; }
        public IMessageConditionValidator PostCondition { get; }
        public bool IncludeDerivedMessageTypes { get; }
        public bool IncludeDerivedHandlerTypes { get; }

        private MessageRouteRule(string name, Type messageType, bool includeDrivedMessageTypes, Type handlerType, bool includeDrivedHandlerTypes, IMessageConditionValidator preCondition, IMessageTransformer transformer, IMessageConditionValidator postCondition)
        {
            Name = name;
            MessageType = messageType;
            IncludeDerivedMessageTypes = includeDrivedMessageTypes;
            HandlerType = handlerType;
            IncludeDerivedHandlerTypes = includeDrivedHandlerTypes;
            PreCondition = preCondition;
            Transformer = transformer;
            PostCondition = postCondition;
        }

        #region Static Constructor

        public static MessageRouteRule Create<TMessageHandler, TMessage>(string name, bool includeSubMessageTypes, Type handlerType, bool includeDrivedHandlerTypes, IMessageConditionValidator<TMessage> preConditionValidator, IMessageTransformer<TMessage, IMessage> transformer, IMessageConditionValidator<TMessageHandler, TMessage> postConditionValidator)
            where TMessageHandler : class, IMessageHandler<TMessage>
            where TMessage : class, IMessage
        {
            var route = new MessageRouteRule(name, typeof(TMessage), includeSubMessageTypes, handlerType, includeDrivedHandlerTypes, preConditionValidator, transformer, postConditionValidator);

            return route;
        }

        public static MessageRouteRule Create<TMessage, TMessageHandler>(string name, bool includeSubMessageTypes, bool includeDrivedHandlerTypes, IMessageConditionValidator<TMessage> preConditionValidator, IMessageTransformer<TMessage, IMessage> transformer, IMessageConditionValidator<TMessageHandler, TMessage> postConditionValidator)
            where TMessage : class, IMessage
            where TMessageHandler : class, IMessageHandler<TMessage>
        {
            var route = new MessageRouteRule(name, typeof(TMessage), includeSubMessageTypes, typeof(TMessageHandler),
                includeDrivedHandlerTypes, preConditionValidator, transformer, postConditionValidator);

            return route;
        }

        public static MessageRouteRule Create<TMessage, TMessageHandler>(string name, bool includeSubMessageTypes, bool includeDrivedHandlerTypes, IMessageConditionValidator<TMessageHandler, TMessage> conditionValidator)
            where TMessage : class, IMessage
            where TMessageHandler : class, IMessageHandler<TMessage>
        {
            var route = new MessageRouteRule(name, typeof(TMessage), includeSubMessageTypes, typeof(TMessageHandler),
                includeDrivedHandlerTypes, null, null, conditionValidator);

            return route;
        }

        public static MessageRouteRule Create<TMessage, TMessageHandler>(string name, bool includeSubMessageTypes, bool includeDrivedHandlerTypes, IMessageConditionValidator<TMessage> conditionValidator)
            where TMessage : class, IMessage
            where TMessageHandler : class, IMessageHandler<TMessage>
        {
            var route = new MessageRouteRule(name, typeof(TMessage), includeSubMessageTypes, typeof(TMessageHandler),
                includeDrivedHandlerTypes, null, null, conditionValidator);

            return route;
        }

        public static MessageRouteRule Create<TMessage>(string name, bool includeSubMessageTypes, Type messageHandler, bool includeDrivedHandlerTypes, IMessageConditionValidator<TMessage> conditionValidator)
            where TMessage : class, IMessage
        {
            var route = new MessageRouteRule(name, typeof(TMessage), includeSubMessageTypes, messageHandler,
                includeDrivedHandlerTypes, null, null, conditionValidator);

            return route;
        }

        public static MessageRouteRule Create<TMessage, TMessageHandler>(string name, bool includeSubMessageTypes, bool includeDrivedHandlerTypes)
            where TMessage : class, IMessage
            where TMessageHandler : class, IMessageHandler<TMessage>
        {
            var route = new MessageRouteRule(name, typeof(TMessage), includeSubMessageTypes, typeof(TMessageHandler),
                includeDrivedHandlerTypes, null, null, null);

            return route;
        }

        public static MessageRouteRule Create<TTransformerInputMessage, TTransformerOutputMessage, TMessageHandler>(
            string name, bool includeSubMessageTypes, bool includeDrivedHandlerTypes, IMessageConditionValidator<TTransformerInputMessage> preConditionValidator,
            IMessageTransformer<TTransformerInputMessage, TTransformerOutputMessage> transformer, IMessageConditionValidator<TMessageHandler, TTransformerOutputMessage> postConditionValidator)

            where TTransformerInputMessage : class, IMessage
            where TTransformerOutputMessage : class, IMessage
            where TMessageHandler : class, IMessageHandler<TTransformerOutputMessage>
        {
            var route = new MessageRouteRule(name, typeof(TTransformerOutputMessage), includeSubMessageTypes, typeof(TMessageHandler),
                includeDrivedHandlerTypes, preConditionValidator, transformer, postConditionValidator);

            return route;
        }

        #endregion
    }

    

    
}