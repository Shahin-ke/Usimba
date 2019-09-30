using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using SH_SWAT.Usimba.EventOrientedModule.CQRS;

namespace SH_SWAT.Usimba.EventOrientedModule
{
    public class EventList : IEventList
    {
        private readonly IMessageBus _messageBus;
        private List<IEvent> _changes = new List<IEvent>();
        private ReadOnlyDictionary<Type, MethodInfo> _handlerCache;
        private object _owner;

        private ReadOnlyDictionary<Type, MethodInfo> HandlerCache
        {
            get
            {
                CheckInit();

                if (null != _handlerCache) return _handlerCache;

                var currentType = _owner.GetType();
                _handlerCache = new ReadOnlyDictionary<Type, MethodInfo>(
                    currentType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .Where(FilterHandlerMethods)
                        .ToDictionary(info => info.GetParameters()[0].ParameterType, info => info));

                return _handlerCache;
            }
        }

        public EventList(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public EventList(IMessageBus messageBus, object owner)
        {
            _messageBus = messageBus;
            _owner = owner;
        }

        public void ApplyChange(IEvent evt, bool isNew)
        {
            CheckInit();

            InvokeHandlerMethod(evt);
            //if (isNew) _changes.Add(evt);
            if (isNew) _messageBus.RaiseEvent(evt);
        }

        public void SetOwner(object obj)
        {
            if (null != _owner)
            {
                throw new Exception("Each list can have single owner. not set owner more than one.");
            }

            _owner = obj;
        }

        private void InvokeHandlerMethod(IEvent evt)
        {
            var eventType = evt.GetType();
            if (HandlerCache.ContainsKey(eventType))
            {
                HandlerCache[eventType].Invoke(_owner, new object[] { evt });
            }
        }

        private bool FilterHandlerMethods(MethodInfo info)
        {
            var isHandlerMethod = string.Equals(info.Name, nameof(IEventHandler<IEvent>.Handle));
            if (!isHandlerMethod) return false;

            isHandlerMethod &= info.DeclaringType == info.ReflectedType;
            if (!isHandlerMethod) return false;

            var parameters = info.GetParameters();
            isHandlerMethod &= 1 == parameters.Length;
            if (!isHandlerMethod) return false;

            isHandlerMethod &= typeof(IEvent).IsAssignableFrom(parameters[0].ParameterType);

            return isHandlerMethod;
        }

        private void CheckInit()
        {
            if (null == _owner)
            {
                throw new Exception("First initialize by SetOwner().");
            }
        }
    }
}