using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using SH_SWAT.Usimba.EventOrientedModule.CQRS;
using UnityEngine;

namespace SH_SWAT.Usimba.MessageBus
{
    public class InterceptorMessageHandler<TMessage> : IMessageHandler<TMessage> where TMessage : class, IMessage
    {
        public int? EntityId => null;

        private static Dictionary<Type, MessageInfos> _registry = new Dictionary<Type, MessageInfos>();

        private static MessageInfos GetInfos(Type messageType)
        {
            if (!_registry.ContainsKey(messageType))
            {
                var properties =
                    messageType.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public)
                        .ToList();

                var fields =
                    messageType.GetFields(BindingFlags.GetField | BindingFlags.Instance | BindingFlags.Public)
                        .ToList();

                _registry.Add(messageType, new MessageInfos(properties, fields));
            }
            return _registry[messageType];
        }

        public static void CreateAndAddInterceptor(IMessageBus messageBus, bool includeSubMessageTypes)
        {
            messageBus.AddRule(MessageRouteRule.Create<TMessage, InterceptorMessageHandler<TMessage>>
            (
                string.Empty,
                includeSubMessageTypes,
                true
            ));

            // TODO: Cache interceptors and if it's not avaliable, create it
            var interceptor = new InterceptorMessageHandler<TMessage>();
            messageBus.Subscribe<InterceptorMessageHandler<TMessage>, TMessage>(interceptor,
                new MessageHandlerActionExecutor<TMessage>(interceptor.Handle));
        }

        public void Handle(TMessage message)
        {
            var messageType = typeof(TMessage);
            var info = GetInfos(messageType);

            var indent = 0;
            var log = new StringBuilder();

            log.Append($"{new string(' ', indent)}Message Type: {message.GetType().FullName}");
            log.Append($"\n{new string(' ', indent)}Properties:");

            indent++;
            foreach (var propertyInfo in info.Properties)
            {
                log.Append($"\n{new string(' ', indent)}{propertyInfo.Name}: {propertyInfo.GetValue(message)}");
            }
            indent--;

            log.Append($"\n\n{new string(' ', indent)}Fields:");
            indent++;
            foreach (var fieldInfo in info.Fields)
            {
                log.Append($"\n{new string(' ', indent + 1)}{fieldInfo.Name}: {fieldInfo.GetValue(message)}");
            }
            indent--;

            Debug.Log(log);
        }

        private class MessageInfos
        {
            public readonly ReadOnlyCollection<PropertyInfo> Properties;
            public readonly ReadOnlyCollection<FieldInfo> Fields;

            public MessageInfos(List<PropertyInfo> propertyInfos, List<FieldInfo> fieldInfos)
            {
                Properties = propertyInfos.AsReadOnly();
                Fields = fieldInfos.AsReadOnly();
            }
        }
    }
}